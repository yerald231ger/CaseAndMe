

namespace CaseAndMeWeb.Models
{
    public class OrdenVentaDetalle : Base<int>
    {
        public int Cantidad { get; set; }

        public int IdOrdenVenta { get; set; }
        public OrdenVenta OrdenVenta { get; set; }

        public int IdProducto { get; set; }
        public Producto Producto { get; set; }

        public int idDipositivo { get; set; }
        public Dispositivo Dispositivo { get; set; }
    }
}
