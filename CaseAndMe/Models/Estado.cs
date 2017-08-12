using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMe.Models
{
    public class Estado : Comun
    {
        public int IdPais { get; set; }

        public Pais Pais { get; set; }

        public ICollection<Ciudad> Ciudades { get; set; }
    }
}
