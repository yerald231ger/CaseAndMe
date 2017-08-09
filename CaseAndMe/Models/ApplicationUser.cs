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
        public int IdOrdenVenta { get; set; }
        public virtual ICollection<OrdenVenta> OrdenesVenta { get; set; }
    }
}
