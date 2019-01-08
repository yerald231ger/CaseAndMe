

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseAndMeWeb.Models
{
    public class Inventario : Comun<int>
    { 
        public virtual Producto Producto { get; set; }

        public int Cantidad { get; set; }
    }
}