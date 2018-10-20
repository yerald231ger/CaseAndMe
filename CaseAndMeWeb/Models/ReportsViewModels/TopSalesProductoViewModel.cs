using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseAndMeWeb.Models.ReportsViewModels
{
    public class TopSalesProductoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Total { get; set; }

        public TopSalesProductoViewModel(int id, string nombre, int total)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Total = total;
        }
    }

    public class SalesWeek 
    {
        public int[] Data { get; } = new int[7];
        public string[] Labels { get; } = new string[7];
    }
}