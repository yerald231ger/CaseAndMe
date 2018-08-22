using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMeWeb.Models
{
    public class Comun<TKey> : Base<TKey>
    {
        public string Nombre { get; set; }
    }
}
