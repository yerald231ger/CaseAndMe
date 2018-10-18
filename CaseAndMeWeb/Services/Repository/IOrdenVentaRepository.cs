using CaseAndMeWeb.Models;
using CaseAndMeWeb.Models.ReportsViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseAndMeWeb.Services.Repository
{
    public interface IOrdenVentaRepository : IRepository<OrdenVenta, int>
    {
        List<OrdenVenta> TopOrdenesDeVenta(int top);
        int[] SalesYearTotalByMonth(int year);
        List<TopSalesProductoViewModel> ProductosMasVendidos();
        SalesWeek SalesWeeks();
    }

    public class OrdenVentaRepository : Repository<OrdenVenta, int>, IOrdenVentaRepository, IDisposable
    {

        public List<OrdenVenta> TopOrdenesDeVenta(int top)
        {
            var ordenesTop = _dbSet.Take(top).Include(ov => ov.MetodoEnvio).Include(ov => ov.MetodoPago);

            return ordenesTop.ToList();
        }

        public int[] SalesYearTotalByMonth(int year)
        {
            var monthSales = new int[12];

            var ordenesDelAño = _dbSet.Where(ov => ov.FechaAlt.Year == year).Select(ov => new { ov.Id, ov.FechaAlt })
                .GroupBy(ov => ov.FechaAlt.Month);

            foreach (var month in ordenesDelAño)
                monthSales[month.Key - 1] = month.Count();

            return monthSales;
        }

        public SalesWeek SalesWeeks()
        {
            var from = DateTime.Now;
            var salesWeek = new SalesWeek();

            from = from.Subtract(new TimeSpan(7, 0, 0, 0));
            var ventasUltimaSemana = _dbSet.Include(ov => ov.OrdenesVentaDetalle)
                .Where(ov => ov.FechaAlt > from).OrderByDescending(ov => ov.FechaAlt).ToList().GroupBy(ov => ov.FechaAlt.DayOfWeek);

            var today = DateTime.Now;
            var labels = new int?[7];

            for (int i = labels.Length - 1; i >= 0; i--)
            {
                if (labels[labels.Length - 1] == null)
                    labels[i] = (int)today.DayOfWeek;
                else
                {
                    var diaPrev = labels[i + 1] - 1;

                    if (diaPrev == -1)
                        diaPrev = 6;

                    labels[i] = diaPrev;
                }

                var ventasDia = ventasUltimaSemana.FirstOrDefault(vd => (int)vd.Key == labels[i]);

                if (ventasDia != null)
                {
                    var ovd = ventasDia.SelectMany(ov => ov.OrdenesVentaDetalle);
                    var cantidad = ovd.Sum(o => o.Cantidad);
                    salesWeek.Data[i] = cantidad;
                }
            }

            for (int i = 0; i < labels.Length; i++)
                salesWeek.Labels[i] = GetName(labels[i].Value) + " " + today.Subtract(new TimeSpan(6 - i, 0, 0, 0)).Day;

            return salesWeek;
        }

        private string GetName(int i)
        {
            switch (i)
            {
                case 1: return "Lunes";
                case 2: return "Martes";
                case 3: return "Miercoles";
                case 4: return "Jueves";
                case 5: return "Viernes";
                case 6: return "Sabado";
                case 0:
                default:
                    return "Domingo";
            }
        }

        public List<TopSalesProductoViewModel> ProductosMasVendidos()
        {
            var list = new List<TopSalesProductoViewModel>();

            var productos = _context.OrdenesVentasDetalle.GroupBy(ovd => ovd.IdProducto).Select(g =>
                new
                {
                    Id = g.Key,
                    Total = g.Sum(ovd => ovd.Cantidad),
                    _context.Productos.FirstOrDefault(p => p.Id == g.Key).Nombre
                }).ToList();

            foreach (var producto in productos)
                list.Add(new TopSalesProductoViewModel(producto.Id, producto.Nombre, producto.Total));

            return list;
        }

        public OrdenVentaRepository(ApplicationDbContext context) : base(context)
        {

        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
