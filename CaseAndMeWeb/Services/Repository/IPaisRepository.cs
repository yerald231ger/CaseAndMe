using CaseAndMeWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CaseAndMeWeb.Services.Repository
{
    public interface IPaisRepository : IRepository<Pais, int>
    {
        ICollection<Estado> GetEstados(int idPais);
    }

    public class PaisRepository : Repository<Pais, int>, IPaisRepository, IDisposable
    {
        private DbSet<Pais> _dbSet { get; set; }

        public PaisRepository(ApplicationDbContext context) : base(context)
        {
            _dbSet = _context.Set<Pais>();
        }

        public ICollection<Estado> GetEstados(int idPais)
        {            
            return _dbSet.Include(p => p.Estados).First(p => p.Id == idPais).Estados;
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
