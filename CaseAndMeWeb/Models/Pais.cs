using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMeWeb.Models
{
    public class Pais : Comun<int>
    {

        public Pais()
        {
            Estados = new HashSet<Estado>();
        }

        public string CountryISO { get; set; }
        
        public virtual ICollection<Estado> Estados { get; set; }

    }
}
