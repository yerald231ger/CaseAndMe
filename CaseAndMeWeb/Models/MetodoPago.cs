using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMeWeb.Models
{
    public class MetodoPago : Comun<int>
    {
        public virtual ICollection<OrdenVenta> OrdenesVenta { get; set; }
    }
}
