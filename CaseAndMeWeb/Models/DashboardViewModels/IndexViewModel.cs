using CaseAndMeWeb.Models.ComponentsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseAndMeWeb.Models.DashboardViewModels
{
    public class IndexViewModel
    {
        public TableViewModel TopOrdenesVenta { get; set; }
        public TableViewModel TopUsuarios { get; set; }
    }
}