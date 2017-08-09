using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CaseAndMe.Data;

namespace CaseAndMe.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170809052634_intial")]
    partial class intial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CaseAndMe.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("IdOrdenVenta");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("tblUser");
                });

            modelBuilder.Entity("CaseAndMe.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("EsActivo");

                    b.Property<DateTime>("FechaAlt");

                    b.Property<DateTime>("FechaMod");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("tblCategorias");
                });

            modelBuilder.Entity("CaseAndMe.Models.MetodoEnvio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("EsActivo");

                    b.Property<DateTime>("FechaAlt");

                    b.Property<DateTime>("FechaMod");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("MetodosEnvios");
                });

            modelBuilder.Entity("CaseAndMe.Models.MetodoPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("EsActivo");

                    b.Property<DateTime>("FechaAlt");

                    b.Property<DateTime>("FechaMod");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("MetodosPagos");
                });

            modelBuilder.Entity("CaseAndMe.Models.OrdenVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("EsActivo");

                    b.Property<DateTime>("FechaAlt");

                    b.Property<DateTime>("FechaMod");

                    b.Property<string>("Folio");

                    b.Property<int>("IdMetodoEnvio");

                    b.Property<int>("IdMetodoPago");

                    b.Property<string>("IdUser");

                    b.HasKey("Id");

                    b.HasIndex("IdMetodoEnvio");

                    b.HasIndex("IdMetodoPago");

                    b.HasIndex("IdUser");

                    b.ToTable("tblOrdenesVenta");
                });

            modelBuilder.Entity("CaseAndMe.Models.OrdenVentaDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cantidad");

                    b.Property<bool>("EsActivo");

                    b.Property<DateTime>("FechaAlt");

                    b.Property<DateTime>("FechaMod");

                    b.Property<int>("IdOrdenVenta");

                    b.Property<int>("IdProducto");

                    b.HasKey("Id");

                    b.HasIndex("IdOrdenVenta");

                    b.HasIndex("IdProducto");

                    b.ToTable("tblOrdenesVentaDetalle");
                });

            modelBuilder.Entity("CaseAndMe.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<bool>("EsActivo");

                    b.Property<DateTime>("FechaAlt");

                    b.Property<DateTime>("FechaMod");

                    b.Property<string>("Nombre");

                    b.Property<float>("Precio");

                    b.Property<string>("UrlImagen");

                    b.HasKey("Id");

                    b.ToTable("tblProductos");
                });

            modelBuilder.Entity("CaseAndMe.Models.ProductoSubCategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("EsActivo");

                    b.Property<DateTime>("FechaAlt");

                    b.Property<DateTime>("FechaMod");

                    b.Property<int>("IdProducto");

                    b.Property<int>("IdSubCategoria");

                    b.HasKey("Id");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdSubCategoria");

                    b.ToTable("ProductosSubCategorias");
                });

            modelBuilder.Entity("CaseAndMe.Models.SubCategoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("EsActivo");

                    b.Property<DateTime>("FechaAlt");

                    b.Property<DateTime>("FechaMod");

                    b.Property<int>("IdCategoria");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("tblSubCategorias");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("tblRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("tblRoleClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("tblUserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("tblUserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("tblUserRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("tblUserToken");
                });

            modelBuilder.Entity("CaseAndMe.Models.OrdenVenta", b =>
                {
                    b.HasOne("CaseAndMe.Models.MetodoEnvio", "MetodoEnvio")
                        .WithMany("OrdenesVenta")
                        .HasForeignKey("IdMetodoEnvio")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CaseAndMe.Models.MetodoPago", "MetodoPago")
                        .WithMany("OrdenesVenta")
                        .HasForeignKey("IdMetodoPago")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CaseAndMe.Models.ApplicationUser", "User")
                        .WithMany("OrdenesVenta")
                        .HasForeignKey("IdUser");
                });

            modelBuilder.Entity("CaseAndMe.Models.OrdenVentaDetalle", b =>
                {
                    b.HasOne("CaseAndMe.Models.OrdenVenta", "OrdenVenta")
                        .WithMany("OrdenesVentaDetalle")
                        .HasForeignKey("IdOrdenVenta")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CaseAndMe.Models.Producto", "Producto")
                        .WithMany("OrdenesVentaDetalle")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CaseAndMe.Models.ProductoSubCategoria", b =>
                {
                    b.HasOne("CaseAndMe.Models.Producto", "Producto")
                        .WithMany("ProductosSubCategorias")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CaseAndMe.Models.SubCategoria", "SubCategoria")
                        .WithMany("ProductosSubCategorias")
                        .HasForeignKey("IdSubCategoria")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CaseAndMe.Models.SubCategoria", b =>
                {
                    b.HasOne("CaseAndMe.Models.Categoria", "Categoria")
                        .WithMany("SubCategorias")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CaseAndMe.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CaseAndMe.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CaseAndMe.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
