using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMe.Models
{
    public class Producto : Comun<int>
    {
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public string UrlImagen { get; set; }

        public int IdSubCategoria { get; set; }

        public SubCategoria SubCategoria { get; set; }
        public virtual ICollection<OrdenVentaDetalle> OrdenesVentaDetalle { get; set; }
    }
}
