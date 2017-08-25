using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaseAndMe.Models.FilterViewModels;
using CaseAndMe.Services.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Razor;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Abstractions;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using CaseAndMe.Models;

namespace CaseAndMe.Controllers
{
    public class FilterController : Controller
    {
        private IProductoRepository _productoRepository;
        private readonly IRazorViewEngine _viewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IServiceProvider _serviceProvider;


        public FilterController(
            IProductoRepository productoRepository,
            IRazorViewEngine viewEngine,
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider)
        {
            _productoRepository = productoRepository;
            _viewEngine = viewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
        }

        public IActionResult Index(string expresion,
            RangePriceFilter rangePriceFilter,
            CategoryFilter categoryFilter,
            List<Producto> productos
            )
        {
            productos = _productoRepository.FiltrarProductos(expresion);

            var leftFilter = SetUpFilters(productos);

            leftFilter.RenderViews();

            return View(new ResultadoViewModel { Productos = productos.ToList(), LeftFilter =  leftFilter });
        }

        private LeftFilterContainer SetUpFilters(List<Producto> productos)
        {
            var fbt = new Task<FilterBase>[]
            {
                GetCategoryFilter(productos),
                GetRangePriceFilter(productos)
            };

            Task.WaitAll(fbt);

            var leftFilter = new LeftFilterContainer(GetSringView);
            foreach (var fb in fbt)
                leftFilter.Add(fb.Result);


            return leftFilter;
        }

        private Task<FilterBase> GetCategoryFilter(List<Producto> productos)
        {
            return Task.Factory.StartNew<FilterBase>(() =>
           {
               var subCategories = productos.GroupBy(p => p.SubCategoria, (k, v) => new Filter<String>
               {
                   Value = k.Nombre,
                   Matched = v.Count()
               }).ToList();

               var categories = productos.GroupBy(p => p.SubCategoria.Categoria, (k, v) => new Filter<String>
               {
                   Value = k.Nombre,
                   Matched = v.Count()
               }).ToList();

               if (categories.Count > 1)
                   subCategories.AddRange(subCategories);

               var cf = new CategoryFilter("Components/Filters/_CategoryFilter");
               subCategories.ForEach(c => cf.Add(c));
               return cf;
           });
        }

        private Task<FilterBase> GetRangePriceFilter(List<Producto> productos)
        {
            return Task.Factory.StartNew<FilterBase>(() =>
            {
                var rangep = productos.GroupBy(p => p.Precio, (k, v) => new { Matched = v.Count(), Value = k }).ToList();

                var min = rangep.Min(p => p.Value);
                var max = rangep.Max(p => p.Value);

                var r1 = max - min;
                var r2 = r1 / 5;

                var rangesPrices = new List<Filter<RangePrice>>();

                for (float i = min; i < max; i = i + r2)
                {
                    var rp = new Filter<RangePrice>
                    {
                        Value = new RangePrice
                        {
                            MinPrice = i,
                            MaxPrice = i + r2
                        }
                    };

                    var selected = rangep.Where(p => (p.Value >= rp.Value.MinPrice && p.Value <= rp.Value.MaxPrice)).ToList();
                    rp.Matched = selected.Sum(s => s.Matched);
                    selected.ForEach(s => rangep.Remove(s));
                    rangesPrices.Add(rp);
                }

                var rpf = new RangePriceFilter("Components/Filters/_RangesPriceFilter");
                rangesPrices.ForEach(rp => rpf.Add(rp));

                return rpf;
            });
        }

        private HtmlString GetSringView<TModel>(string viewPath, TModel model)
        {
            var actionContext = GetActionContext();
            var viewEngineResult = _viewEngine.FindView(actionContext, viewPath, false);

            if (!viewEngineResult.Success)
            {
                throw new InvalidOperationException(string.Format("Couldn't find view '{0}'", viewPath));
            }

            var view = viewEngineResult.View;

            using (var output = new StringWriter())
            {
                var viewContext = new ViewContext(
                    actionContext,
                    view,
                    new ViewDataDictionary<TModel>(
                        metadataProvider: new EmptyModelMetadataProvider(),
                        modelState: new ModelStateDictionary())
                    {
                        Model = model
                    },
                    new TempDataDictionary(
                        ControllerContext.HttpContext,
                        _tempDataProvider),
                    output,
                    new HtmlHelperOptions());

                view.RenderAsync(viewContext).Wait();
                return new HtmlString(output.ToString());
            }
        }

        private ActionContext GetActionContext()
        {
            var httpContext = new DefaultHttpContext
            {
                RequestServices = _serviceProvider
            };

            return new ActionContext(httpContext, new RouteData(), new ActionDescriptor());
        }
    }

}