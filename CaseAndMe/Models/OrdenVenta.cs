using CaseAndMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMe.Models
{
    public class OrdenVenta : Base<int>
    {
        public string Folio { get; set; }

        public int IdMetodoPago { get; set; }
        public MetodoPago MetodoPago { get; set; }

        public int IdMetodoEnvio { get; set; }
        public MetodoEnvio MetodoEnvio { get; set; }

        public string IdUser { get; set; }
        public ApplicationUser User { get; set; }

        public virtual ICollection<OrdenVentaDetalle> OrdenesVentaDetalle { get; set; }
    }
}
