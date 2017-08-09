using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMe.Models
{
    public class ProductoSubCategoria : Base
    {
        public int IdProducto { get; set; }
        public int IdSubCategoria { get; set; }

        public virtual SubCategoria  SubCategoria { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
