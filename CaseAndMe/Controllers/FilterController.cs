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

namespace CaseAndMe.Controllers
{
    public class FilterController : Controller
    {
        private IProductoRepository _productoRepository;
        private readonly IRazorViewEngine _viewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IServiceProvider _serviceProvider;


        public FilterController(IProductoRepository productoRepository, IRazorViewEngine viewEngine,
            ITempDataProvider tempDataProvider,
            IServiceProvider serviceProvider)
        {
            _productoRepository = productoRepository;
            _viewEngine = viewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;
        }

        public IActionResult Index(string expresion,
            RatingFilter ratingFilter,
            RangePriceFilter rangePriceFilter,
            MaterialFilter materialFilter,
            CategoryFilter categoryFilter
            )
        {


            var filters = new LeftFilterContainer();

            var productos = _productoRepository.FiltrarProductos(expresion);

            var mf = new MaterialFilter();
            mf.Add(new Filter<string> { Value = "MA" });
            mf.Add(new Filter<string> { Value = "MS" });

            var cf = new CategoryFilter();
            cf.Add(new Filter<string> { Value = "A" });
            cf.Add(new Filter<string> { Value = "C" });

            var rf = new RatingFilter();
            rf.Add(new Filter<Stars> { Value = Stars.One });
            rf.Add(new Filter<Stars> { Value = Stars.Three });
            rf.Add(new Filter<Stars> { Value = Stars.Five });

            var rpf = new RangePriceFilter();
            rpf.Add(new Filter<RangePrice> { Value = new RangePrice { MinPrice = 1, MaxPrice = 2 } });
            rpf.Add(new Filter<RangePrice> { Value = new RangePrice { MinPrice = 1, MaxPrice = 2 } });

            filters.Add(rf);
            filters.Add(rpf);
            filters.Add(cf);
            filters.Add(mf);

            var taskMf = GetSringView("Components/Filters/_MaterialFilter", mf);
            var taskCf = GetSringView("Components/Filters/_CategoryFilter", cf);
            var taskRf = GetSringView("Components/Filters/_RatingFilter", rf);
            var taskRpf = GetSringView("Components/Filters/_RangesPriceFilter", rpf);

            rpf.ViewString = taskRpf.Result;
            rf.ViewString = taskRf.Result;
            cf.ViewString = taskCf.Result;
            mf.ViewString = taskMf.Result;

            return View(new ResultadoViewModel { Productos = productos.ToList(), LeftFilter = filters });
        }

        private async Task<HtmlString> GetSringView<TModel>(string viewPath, TModel model)
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

                await view.RenderAsync(viewContext);
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