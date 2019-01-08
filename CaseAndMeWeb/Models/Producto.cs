
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseAndMeWeb.Models
{
    public class Producto : Comun<int>
    {
        public string Descripcion { get; set; }

        public string Codigo { get; set; }

        [RegularExpression("[0-9]+(\\.[0-9][0-9]?)?", ErrorMessage ="Solo se permiten decimales")]
        public float Precio { get; set; }
        public string UrlImagen { get; set; }

        public int IdSubCategoria { get; set; }
        public SubCategoria SubCategoria { get; set; }

        public virtual ICollection<OrdenVentaDetalle> OrdenesVentaDetalle { get; set; }


        
        public virtual Inventario Inventario { get; set; }

    }
}
