using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseAndMe.Models
{
    public class Categoria : Comun
    {
        public virtual ICollection<SubCategoria> SubCategorias { get; set; }
    }
}
