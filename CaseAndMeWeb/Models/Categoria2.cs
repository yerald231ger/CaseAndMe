using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseAndMeWeb.Models
{
    public class Categoria2
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public int NoSubCategoria { get; set; }
        public bool EsActivo { get; set; }
    }
}