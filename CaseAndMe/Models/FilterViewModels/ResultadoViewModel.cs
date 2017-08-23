using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMe.Models.FilterViewModels
{
    public class ResultadoViewModel
    {
        public string Resultado { get; set; }
        public TopFilter TopFilter { get; set; }
        public LeftFilter LeftFilter { get; set; }
    }

    public class TopFilter
    {

    }

    public class LeftFilter
    {
    }

    public class CategoryFilter : IFilterName<string>
    {
        public string Name => "Categoria";
        public IList<Filter<string>> Filters { get; set; }
    }

    public class MaterialFilter : IFilterName<string>
    {
        public string Name => "Material";
        public IList<Filter<string>> Filters { get; set; }
    }

    public class RangePriceFilter : IFilterName<RangePrice>
    {
        public string Name => "Rango de precios";
        public IList<Filter<RangePrice>> Filters { get; set; }
    }

    public class RangePrice
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }

    public class RatingFilter : IFilterName<Stars>
    {
        public string Name => "Rating";
        public IList<Filter<Stars>> Filters { get; set; }
    }

    public enum Stars { One, Two, Three, Fourt, Five }

    public interface IFilterName<TFilter>
    {
        string Name { get; }
        IList<Filter<TFilter>> Filters { get; set; }
    }

    public class Filter<TFilter>
    {
        public bool Selected { get; }
        public TFilter TypeFilter { get; set; }
        public int Matched { get; set; }
    }
}
