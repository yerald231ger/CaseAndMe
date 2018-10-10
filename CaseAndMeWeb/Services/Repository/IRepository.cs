using CaseAndMeWeb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CaseAndMeWeb.Services.Repository
{
    public interface IRepository<TEntity, TKey> where TEntity : Base<TKey>
    {
        ICollection<TEntity> GetAll();
        ICollection<TEntity> GetTop(int top);
        void Update(TEntity entity);
        int UpdateNow(TEntity entity);
        int Count();
    }

    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : Base<TKey>
    {
        protected DbContext _context { get; set; }
        protected DbSet<TEntity> _dbSet { get; set; }

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
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

        public int Count()
        {
            return _dbSet.Count();
        }

        public ICollection<TEntity> GetTop(int top)
        {
            return _dbSet.Take(top).ToList();
        }
    }
}
