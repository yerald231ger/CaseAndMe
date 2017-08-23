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
        public LeftFilterContainer()
        {
            FilterCategories = new List<FilterBase>();
        }

        public List<FilterBase> FilterCategories { get; }

        public void Add(FilterBase filterCategory)
        {
            FilterCategories.Add(filterCategory);
        }
    }

    public class CategoryFilter : FilterBase
    {
        public CategoryFilter() : base("Categoria", FilterType.Category)
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
        public MaterialFilter() : base("Material", FilterType.Material)
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
        public RangePriceFilter() : base("Rango de precios", FilterType.PriceRange)
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
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }

    public class RatingFilter : FilterBase
    {
        public RatingFilter() : base("Rating", FilterType.Rating)
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
        public FilterBase(string name, FilterType filter)
        {
            Name = name;
            FilterType = filter;
        }

        public string Name { get; }
        public FilterType FilterType { get; }
    }    

    public class Filter<TFilter>
    {
        public bool Selected { get; set; }
        public TFilter Value { get; set; }
        public int Matched { get; set; }
    }
}
