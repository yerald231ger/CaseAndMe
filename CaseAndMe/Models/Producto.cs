using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMe.Models
{
    public class Producto : Comun<int>, IEqualityComparer<Producto>
    {
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public string UrlImagen { get; set; }

        public int IdSubCategoria { get; set; }

        public SubCategoria SubCategoria { get; set; }
        public virtual ICollection<OrdenVentaDetalle> OrdenesVentaDetalle { get; set; }

        public bool Equals(Producto x, Producto y)
        {
            return x.Descripcion.Contains(y.Descripcion)
                || x.Nombre.Contains(y.Nombre)
                || (x.IdSubCategoria == y.IdSubCategoria);
        }

        public int GetHashCode(Producto obj)
        {
            return GetHashCode();
        }
    }
}
