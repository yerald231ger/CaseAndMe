using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMeWeb.Models
{
    public class BitacoraError : Base<int>
    {
        public string Metodo { get; set; }
        public string Descripcion { get; set; }
    }
}
