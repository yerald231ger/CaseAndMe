using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMeWeb.Models
{
    public class OrdenVentaDetalle : Base<int>
    {
        public int Cantidad { get; set; }

        public int IdOrdenVenta { get; set; }
        public OrdenVenta OrdenVenta { get; set; }

        public int IdProducto { get; set; }
        public Producto Producto { get; set; }


    }
}
