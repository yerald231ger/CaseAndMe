using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMe.Models
{
    public class MetodoPago : Comun
    {
        public virtual ICollection<OrdenVenta> OrdenesVenta { get; set; }
    }
}
