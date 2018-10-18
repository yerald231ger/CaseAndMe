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

    public class SalesYearViewModel
    {
        public SalesYearViewModel(int year)
        {
            Year = year;
            Months = new List<Month>(12);
        }

        public int Year { get; }
        public List<Month> Months { get; }

        public class Month
        {
            public Month(int id)
            {
                Id = id;
                Sales = new List<Sale>();
            }

            public int Id { get; set; }
            public List<Sale> Sales { get; set; }
        }

        public class Sale
        {
            public Sale(int id, DateTime date)
            {
                Id = id;
                Date = date;
            }

            public int Id { get; set; }
            public DateTime Date { get; set; }
        }
    }
}