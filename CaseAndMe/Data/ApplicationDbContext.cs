using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CaseAndMe.Models;

namespace CaseAndMe.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);     
            builder.Entity<ApplicationUser>().ToTable("tblUser");
            builder.Entity<IdentityRole>().ToTable("tblRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("tblUserClaim");
            builder.Entity<IdentityUserRole<string>>().ToTable("tblUserRole");
            builder.Entity<IdentityUserLogin<string>>().ToTable("tblUserLogin");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("tblRoleClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("tblUserToken");

            builder.Entity<Producto>(build =>
            {
                build.ToTable("tblProductos");

                build.HasOne(p => p.SubCategoria)
                .WithMany(sc => sc.Productos)
                .HasForeignKey(p => p.IdSubCategoria);
            });

            builder.Entity<Categoria>(build =>
            {
                build.ToTable("tblCategorias");

                build.HasMany(c => c.SubCategorias)
                .WithOne(sb => sb.Categoria)
                .HasForeignKey(sb => sb.IdCategoria);
            });

            builder.Entity<SubCategoria>(build =>
            {
                build.ToTable("tblSubCategorias");
            });

            builder.Entity<OrdenVenta>(build =>
            {
                build.ToTable("tblOrdenesVenta");

                build.HasOne(ov => ov.User)
                .WithMany(u => u.OrdenesVenta)
                .HasForeignKey(ov => ov.IdUser);

                build.HasOne(ov => ov.MetodoPago)
                .WithMany(mp => mp.OrdenesVenta)
                .HasForeignKey(ov => ov.IdMetodoPago);

                build.HasOne(ov => ov.MetodoEnvio)
                .WithMany(me => me.OrdenesVenta)
                .HasForeignKey(ov => ov.IdMetodoEnvio);
            });

            builder.Entity<OrdenVentaDetalle>(build =>
            {
                build.ToTable("tblOrdenesVentaDetalle");

                build.HasOne(ovd => ovd.OrdenVenta)
                .WithMany(ov => ov.OrdenesVentaDetalle)
                .HasForeignKey(ovd => ovd.IdOrdenVenta);

                build.HasOne(ovd => ovd.Producto)
                .WithMany(p => p.OrdenesVentaDetalle)
                .HasForeignKey(ovd => ovd.IdProducto);
            });

            builder.Entity<Ciudad>(build =>
            {
                build.ToTable("tblCiudades");

                build.HasOne(c => c.Estado)
                .WithMany(e => e.Ciudades)
                .HasForeignKey(c => c.IdEstado);

                build.HasMany(c => c.Users)
                .WithOne(u => u.Ciudad)
                .HasForeignKey(u => u.IdCiudad);
            });

            builder.Entity<Estado>(build =>
            {
                build.ToTable("tblEstados");

                build.HasOne(e => e.Pais)
                .WithMany(p => p.Estados)
                .HasForeignKey(e => e.IdPais);
            });

            builder.Entity<Material>(build => { build.ToTable("tblMateriales"); });

            builder.Entity<Pais>(build => { build.ToTable("tblPaises"); });

            builder.Entity<MetodoEnvio>(build => { build.ToTable("tblMetodosEnvio"); });

            builder.Entity<MetodoPago>(build => { build.ToTable("tblMetodosPago"); });

        }
    }
}
