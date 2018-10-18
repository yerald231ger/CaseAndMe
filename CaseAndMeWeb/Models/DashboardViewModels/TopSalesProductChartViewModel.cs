using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseAndMeWeb.Models.DashboardViewModels
{
    public class TopSalesProductChartViewModel
    {
        public TopSalesProductChartViewModel() { }

        public TopSalesProductChartViewModel(string[] labels, int[] data, int[] ids, int totalVendidos)
        {
            Labels = labels;
            Data = data;
            Ids = ids;
            TotalVendidos = totalVendidos;
        }

        public int TotalVendidos { get; set; }
        public string[] Labels { get; set; }
        public int[] Data { get; set; }
        public int[] Ids { get; set; }
    }    
}