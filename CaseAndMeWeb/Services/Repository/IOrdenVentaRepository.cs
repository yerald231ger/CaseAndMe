using CaseAndMeWeb.Models;
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
    }

    public class OrdenVentaRepository : Repository<OrdenVenta, int>, IOrdenVentaRepository, IDisposable
    {
        private DbSet<OrdenVenta> _dbSet { get; set; }

        public List<OrdenVenta> TopOrdenesDeVenta(int top)
        {
           var ordenesTop = _dbSet.Take(top).Include(ov => ov.MetodoEnvio).Include(ov => ov.MetodoPago);

            return ordenesTop.ToList();
        }

        public OrdenVentaRepository(ApplicationDbContext context) : base(context)
        {
            _dbSet = _context.Set<OrdenVenta>();
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
