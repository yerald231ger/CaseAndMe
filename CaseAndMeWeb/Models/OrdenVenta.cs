using System.Collections.Generic;

namespace CaseAndMeWeb.Models
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

        //Datos de Envio
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CP { get; set; }
        public string Ciudad { get; set; }
        public string Colonia { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<OrdenVentaDetalle> OrdenesVentaDetalle { get; set; }
    }
}
