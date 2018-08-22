using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMeWeb.Models
{
    public class Estado : Comun<int>
    {          

        public int IdPais { get; set; }

        public Pais Pais { get; set; }

        public virtual ICollection<Ciudad> Ciudades { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
