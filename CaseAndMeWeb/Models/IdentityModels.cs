using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CaseAndMeWeb.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Colonia { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public int CP { get; set; }
        public DateTime FechaMod { get; set; }
        public DateTime FechaAlt { get; set; }

        public int IdEstado { get; set; }
        public Estado Estado { get; set; }

        public virtual ICollection<OrdenVenta> OrdenesVenta { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<MetodoEnvio> MetodosEnvios { get; set; }
        public virtual DbSet<MetodoPago> MetodosPagos { get; set; }
        public virtual DbSet<OrdenVenta> OrdenesVentas { get; set; }
        public virtual DbSet<OrdenVentaDetalle> OrdenesVentasDetalle { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<SubCategoria> SubCategorias { get; set; }
        public virtual DbSet<Pais> Paises { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Dispositivo> Dispositivo { get; set; }
        public virtual DbSet<Material> Material { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);     
            builder.Entity<IdentityRole>().ToTable("tblRole");
            builder.Entity<IdentityUserClaim>().ToTable("tblUserClaim");
            builder.Entity<IdentityUserRole>().ToTable("tblUserRole");
            builder.Entity<IdentityUserLogin>().ToTable("tblUserLogin");

            var tblUser = builder.Entity<ApplicationUser>();

            tblUser.ToTable("tblUser");
            tblUser.HasRequired(u => u.Estado)
                .WithMany(e => e.Users)
                .HasForeignKey(u => u.IdEstado);

            var tblProducto = builder.Entity<Producto>();

            tblProducto.ToTable("tblProductos");

            tblProducto.HasRequired(p => p.SubCategoria)
                .WithMany(sc => sc.Productos)
                .HasForeignKey(p => p.IdSubCategoria);


            var tblCategoria = builder.Entity<Categoria>();

            tblCategoria.ToTable("tblCategorias");

            tblCategoria.HasMany(c => c.SubCategorias)
                .WithRequired(sb => sb.Categoria)
                .HasForeignKey(sb => sb.IdCategoria);


            builder.Entity<SubCategoria>().ToTable("tblSubCategorias");            

            var tblOrdenVenta = builder.Entity<OrdenVenta>();

            tblOrdenVenta.ToTable("tblOrdenesVenta");

            tblOrdenVenta.HasRequired(ov => ov.User)
                .WithMany(u => u.OrdenesVenta)
                .HasForeignKey(ov => ov.IdUser);

            tblOrdenVenta.HasRequired(ov => ov.MetodoPago)
                .WithMany(mp => mp.OrdenesVenta)
                .HasForeignKey(ov => ov.IdMetodoPago);

            tblOrdenVenta.HasRequired(ov => ov.MetodoEnvio)
                .WithMany(me => me.OrdenesVenta)
                .HasForeignKey(ov => ov.IdMetodoEnvio);

            var tblOrdenVentaDetalle = builder.Entity<OrdenVentaDetalle>();

            tblOrdenVentaDetalle.ToTable("tblOrdenesVentaDetalle");

            tblOrdenVentaDetalle.HasRequired(ovd => ovd.OrdenVenta)
                .WithMany(ov => ov.OrdenesVentaDetalle)
                .HasForeignKey(ovd => ovd.IdOrdenVenta);

            tblOrdenVentaDetalle.HasRequired(ovd => ovd.Producto)
                .WithMany(p => p.OrdenesVentaDetalle)
                .HasForeignKey(ovd => ovd.IdProducto);

            var tblCiudad = builder.Entity<Ciudad>();
            tblCiudad.ToTable("tblCiudades");

            tblCiudad.HasRequired(c => c.Estado)
                .WithMany(e => e.Ciudades)
                .HasForeignKey(c => c.IdEstado);

            var tblEstado = builder.Entity<Estado>();

            tblEstado.ToTable("tblEstados");

            tblEstado
                .HasRequired(e => e.Pais)
                .WithMany(p => p.Estados)
                .HasForeignKey(e => e.IdPais);

            builder.Entity<Material>().ToTable("tblMateriales");

            builder.Entity<Pais>().ToTable("tblPaises");

            builder.Entity<MetodoEnvio>().ToTable("tblMetodosEnvio");

            builder.Entity<MetodoPago>().ToTable("tblMetodosPago");

            builder.Entity<Dispositivo>().ToTable("tblDispositivo");

        }
    }
}