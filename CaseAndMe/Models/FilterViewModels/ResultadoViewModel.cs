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

    //public class CateforyFilter : IFilter
    //{
    //    public string Name => "Categoria";
    //    public Stars Stars { get; set; }
    //}

    //public class MaterialFilter : IFilter 
    //{
    //    public string Name => "Material";
    //    public IList<string> Materiales { get; set; }
    //}

    //public class RangePriceFilter : IFilter<>
    //{
    //    public string Name => "Rango de precios";
    //    public Stars Stars { get; set; }
    //}

    //public class RangePrice
    //{

    //}

    //public class RatingFilter : IFilter<Stars>
    //{
    //    public string Name => "Rating";
    //    public IList<Dictionary<Stars, bool>> Selecteds { get; set; }
    //}

    //public enum Stars { One, Two, Three, Fourt, Five }

    public class Filter<TFilter>
    {
        bool Name { get; }
        TFilter TypeFilter { get; set; }
        int Matched { get; set; }
    }
}
