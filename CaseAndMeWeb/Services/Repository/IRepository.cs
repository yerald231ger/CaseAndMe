using CaseAndMeWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace CaseAndMeWeb.Services.Repository
{
    public interface IRepository<TEntity, TKey> where TEntity : Base<TKey>
    {
        ICollection<TEntity> GetAll();
    }

    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Base<TKey>
    {
        protected ApplicationDbContext _context { get; set; }

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
    }
}
