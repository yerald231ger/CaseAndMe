using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMe.Models.FilterViewModels
{
    public class ResultadoViewModel
    {
        public List<Producto> Productos { get; set; }
        public TopFilterContainer TopFilter { get; set; }
        public LeftFilterContainer LeftFilter { get; set; }
    }

    public class TopFilterContainer
    {

    }

    public class LeftFilterContainer
    {
        private Func<string, FilterBase, HtmlString> _renderAction;

        public LeftFilterContainer(Func<string, FilterBase, HtmlString> renderAction)
        {
            FilterCategories = new List<FilterBase>();
            _renderAction = renderAction;
        }

        public List<FilterBase> FilterCategories { get; }

        public void Add(FilterBase filterCategory)
        {
            FilterCategories.Add(filterCategory);
        }

        public void RenderViews()
        {
            var taskFilters = new Task<HtmlString>[FilterCategories.Count];

            for (int i = 0; i < taskFilters.Length; i++)
            {
                var path = FilterCategories[i].ViewPath;
                var obj = FilterCategories[i];
                taskFilters[i] = Task.Factory.StartNew(() => _renderAction(path, obj));
            }

            Task.WaitAll(taskFilters);

            for (int i = 0; i < taskFilters.Length; i++)
                FilterCategories[i].ViewString = taskFilters[i].Result;
        }
    }

    public class CategoryFilter : FilterBase
    {
        public CategoryFilter():base()
        {
            CategoriesFilters = new List<Filter<string>>();
        }
        public CategoryFilter(string viewPath) : base("Categoria", viewPath, FilterType.Category)
        {
            CategoriesFilters = new List<Filter<string>>();
        }

        public List<Filter<string>> CategoriesFilters { get; }

        public void Add(Filter<string> filter)
        {
            CategoriesFilters.Add(filter);
        }
    }

    public class MaterialFilter : FilterBase
    {
        public MaterialFilter():base()
        {
            MaterialsFilters = new List<Filter<string>>();
        }
        public MaterialFilter(string viewPath) : base("Material", viewPath, FilterType.Material)
        {
            MaterialsFilters = new List<Filter<string>>();
        }

        public List<Filter<string>> MaterialsFilters { get; }

        public void Add(Filter<string> filter)
        {
            MaterialsFilters.Add(filter);
        }
    }

    public class RangePriceFilter : FilterBase
    {
        public RangePriceFilter():base()
        {
            RangesFilters = new List<Filter<RangePrice>>();
        }
        public RangePriceFilter(string viewPath) : base("Rango de precios", viewPath, FilterType.PriceRange)
        {
            RangesFilters = new List<Filter<RangePrice>>();
        }

        public List<Filter<RangePrice>> RangesFilters { get; }

        public void Add(Filter<RangePrice> filter)
        {
            RangesFilters.Add(filter);
        }
    }

    public class RangePrice
    {
        public float MinPrice { get; set; }
        public float MaxPrice { get; set; }
    }

    public class RatingFilter : FilterBase
    {
        public RatingFilter():base()
        {
            RatingsFilters = new List<Filter<Stars>>();
        }

        public RatingFilter(string viewPath) : base("Rating", viewPath, FilterType.Rating)
        {
            RatingsFilters = new List<Filter<Stars>>();
        }

        public List<Filter<Stars>> RatingsFilters { get; }

        public void Add(Filter<Stars> filter)
        {
            RatingsFilters.Add(filter);
        }
    }

    public enum Stars { One = 1, Two, Three, Fourt, Five }
    public enum FilterType { Brand, Model, PriceRange, Rating, Category, Color, Material }

    public class FilterBase
    {
        public FilterBase() { }

        public FilterBase(string name, string viewPath,FilterType filter)
        {
            Name = name;
            FilterType = filter;
            ViewPath = viewPath;
        }

        public string Name { get; }
        public FilterType FilterType { get; }
        public string ViewPath { get; set; }
        public HtmlString ViewString { get; set; }
    }

    public class Filter<TFilter>
    {
        public bool Selected { get; set; }
        public TFilter Value { get; set; }
        public int Matched { get; set; }
    }
}
