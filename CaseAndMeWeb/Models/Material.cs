using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMeWeb.Models
{
    public class Material : Comun<int>
    {
        public string Descripcion { get; set; }
        public string Colores { get; set; }
        public string imagen { get; set; }
    }
}
