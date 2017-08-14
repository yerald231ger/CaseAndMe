using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CaseAndMe.Data;

namespace CaseAndMe.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string Direccion { get; set; }
        public int IdOrdenVenta { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Colonia { get; set; }
        public string Telefono { get; set; }
        public string Telefono2 { get; set; }
        public DateTime FechaMod { get; set; }
        public DateTime FechaAlt { get; set; }

        public int IdCiudad { get; set; }
        public Ciudad Ciudad { get; set; }

        public virtual ICollection<OrdenVenta> OrdenesVenta { get; set; }
    }
}
