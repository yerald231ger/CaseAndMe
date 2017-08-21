using CaseAndMe.Data;
using CaseAndMe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMe.Services.Repository
{
    public interface IProductoRepository : IRepository<Producto, int>
    {
        ICollection<Producto> FiltrarProductos(string expression);
    }

    public class ProductoRepository : Repository<Producto, int>, IProductoRepository, IDisposable
    {
        private DbSet<Producto> _dbSet { get; set; }

        public ProductoRepository(ApplicationDbContext context) : base(context)
        {
            _dbSet = _context.Set<Producto>();
        }

        public ICollection<Producto> FiltrarProductos(string expression)
        {
            throw new NotImplementedException();
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
