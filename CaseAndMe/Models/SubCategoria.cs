using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMe.Models
{
    public class SubCategoria : Comun
    {
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }
        
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
