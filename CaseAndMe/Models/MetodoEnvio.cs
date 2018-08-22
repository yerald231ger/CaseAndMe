using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMe.Models
{
    public class MetodoEnvio : Comun<int>
    {
        public virtual ICollection<OrdenVenta> OrdenesVenta { get; set; }
    }
}
