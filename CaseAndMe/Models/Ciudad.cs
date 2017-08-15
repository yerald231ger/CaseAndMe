using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMe.Models
{
    public class Ciudad : Comun<int>
    {
        public int IdEstado { get; set; }

        public Estado Estado { get; set; }
        
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
