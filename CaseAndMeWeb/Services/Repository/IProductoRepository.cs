using CaseAndMeWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CaseAndMeWeb.Services.Repository
{
    public interface IProductoRepository : IRepository<Producto, int>
    {
        List<Producto> FiltrarProductos(string expression);
    }

    public class ProductoRepository : Repository<Producto, int>, IProductoRepository, IDisposable
    {
        private DbSet<Producto> _dbSet { get; set; }

        public ProductoRepository(DbContext context) : base(context)
        {
            _dbSet = _context.Set<Producto>();
        }

        public List<Producto> FiltrarProductos(string expression)
        {
            return _dbSet.Where(p => p.Nombre.Contains(expression)).Include(p => p.SubCategoria.Categoria).ToList();
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
