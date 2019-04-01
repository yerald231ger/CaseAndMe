

namespace CaseAndMeWeb.Models
{
    public class OrdenVentaDetalle : Base<int>
    {
        public int Cantidad { get; set; }

        public int IdOrdenVenta { get; set; }
        public OrdenVenta OrdenVenta { get; set; }

        public int IdProducto { get; set; }
        public Producto Producto { get; set; }

        public int IdDipositivo { get; set; }
        public Dispositivo Dispositivo { get; set; }


        public int IdMaterial { get; set; }
        public Material Material { get; set; }


        public double Precio { get; set; }

        public bool isCustom { get; set; }
        public string Imagen { get; set; }
    }
}
