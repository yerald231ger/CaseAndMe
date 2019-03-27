using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseAndMeWeb.Models
{
    public class Dispositivo : Comun<int>
    {
        public virtual ICollection<OrdenVentaDetalle> OrdenesVentaDetalle { get; set; }
        public string  Marca { get; set; }

        public string Mascaras { get; set; }
    }
}