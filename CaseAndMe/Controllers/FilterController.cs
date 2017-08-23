using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CaseAndMe.Models.FilterViewModels;
using CaseAndMe.Services.Repository;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CaseAndMe.Controllers
{
    public class FilterController : Controller
    {
        private IProductoRepository _productoRepository;

        public FilterController(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
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

            return View(new ResultadoViewModel {  Productos = productos.ToList(), LeftFilter = filters });
        }
    }

    public class CMB : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            throw new NotImplementedException();
        }
    }
}