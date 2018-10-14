using CaseAndMeWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseAndMeWeb.Services.Repository
{
    public interface IUserRepository 
    {
        int Count();
        List<ApplicationUser> Get(int top);
    }

    public class UserRepository : IUserRepository
    {
        private DbSet<ApplicationUser> _dbSet { get; set; }

        public UserRepository(DbContext context) 
        {
            _dbSet = context.Set<ApplicationUser>();
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public List<ApplicationUser> Get(int top)
        {
            return _dbSet.Take(top).ToList();
        }
    }
}
