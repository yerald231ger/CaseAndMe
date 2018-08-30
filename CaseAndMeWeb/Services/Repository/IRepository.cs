using CaseAndMeWeb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CaseAndMeWeb.Services.Repository
{
    public interface IRepository<TEntity, TKey> where TEntity : Base<TKey>
    {
        ICollection<TEntity> GetAll();
        void Update(TEntity entity);
        int UpdateNow(TEntity entity);
    }

    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Base<TKey>
    {
        protected ApplicationDbContext _context { get; set; }
        protected DbSet<TEntity> _dbSet { get; set; }

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public int UpdateNow(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }

    }
}
