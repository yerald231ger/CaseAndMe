namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCategorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaMod = c.DateTime(nullable: false),
                        FechaAlt = c.DateTime(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblSubCategorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdCategoria = c.Int(nullable: false),
                        Nombre = c.String(),
                        FechaMod = c.DateTime(nullable: false),
                        FechaAlt = c.DateTime(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategorias", t => t.IdCategoria, cascadeDelete: true)
                .Index(t => t.IdCategoria);
            
            CreateTable(
                "dbo.tblProductos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Precio = c.Single(nullable: false),
                        UrlImagen = c.String(),
                        IdSubCategoria = c.Int(nullable: false),
                        Nombre = c.String(),
                        FechaMod = c.DateTime(nullable: false),
                        FechaAlt = c.DateTime(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblSubCategorias", t => t.IdSubCategoria, cascadeDelete: true)
                .Index(t => t.IdSubCategoria);
            
            CreateTable(
                "dbo.tblOrdenesVentaDetalle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        IdOrdenVenta = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        FechaMod = c.DateTime(nullable: false),
                        FechaAlt = c.DateTime(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblOrdenesVenta", t => t.IdOrdenVenta, cascadeDelete: true)
                .ForeignKey("dbo.tblProductos", t => t.IdProducto, cascadeDelete: true)
                .Index(t => t.IdOrdenVenta)
                .Index(t => t.IdProducto);
            
            CreateTable(
                "dbo.tblOrdenesVenta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Folio = c.String(),
                        IdMetodoPago = c.Int(nullable: false),
                        IdMetodoEnvio = c.Int(nullable: false),
                        IdUser = c.String(nullable: false, maxLength: 128),
                        FechaMod = c.DateTime(nullable: false),
                        FechaAlt = c.DateTime(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblMetodosEnvio", t => t.IdMetodoEnvio, cascadeDelete: true)
                .ForeignKey("dbo.tblMetodosPago", t => t.IdMetodoPago, cascadeDelete: true)
                .ForeignKey("dbo.tblUser", t => t.IdUser, cascadeDelete: true)
                .Index(t => t.IdMetodoPago)
                .Index(t => t.IdMetodoEnvio)
                .Index(t => t.IdUser);
            
            CreateTable(
                "dbo.tblMetodosEnvio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaMod = c.DateTime(nullable: false),
                        FechaAlt = c.DateTime(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblMetodosPago",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaMod = c.DateTime(nullable: false),
                        FechaAlt = c.DateTime(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Direccion = c.String(),
                        PrimerApellido = c.String(),
                        SegundoApellido = c.String(),
                        Colonia = c.String(),
                        Telefono = c.String(),
                        Ciudad = c.String(),
                        FechaMod = c.DateTime(nullable: false),
                        FechaAlt = c.DateTime(nullable: false),
                        IdEstado = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblEstados", t => t.IdEstado, cascadeDelete: true)
                .Index(t => t.IdEstado)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.tblUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tblEstados",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPais = c.Int(nullable: false),
                        Nombre = c.String(),
                        FechaMod = c.DateTime(nullable: false),
                        FechaAlt = c.DateTime(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblPaises", t => t.IdPais, cascadeDelete: true)
                .Index(t => t.IdPais);
            
            CreateTable(
                "dbo.tblCiudades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdEstado = c.Int(nullable: false),
                        Nombre = c.String(),
                        FechaMod = c.DateTime(nullable: false),
                        FechaAlt = c.DateTime(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblEstados", t => t.IdEstado, cascadeDelete: true)
                .Index(t => t.IdEstado);
            
            CreateTable(
                "dbo.tblPaises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryISO = c.String(),
                        Nombre = c.String(),
                        FechaMod = c.DateTime(nullable: false),
                        FechaAlt = c.DateTime(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblUserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.tblUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tblUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.tblUser", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.tblRole", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.tblRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.tblMateriales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaMod = c.DateTime(nullable: false),
                        FechaAlt = c.DateTime(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUserRole", "RoleId", "dbo.tblRole");
            DropForeignKey("dbo.tblSubCategorias", "IdCategoria", "dbo.tblCategorias");
            DropForeignKey("dbo.tblProductos", "IdSubCategoria", "dbo.tblSubCategorias");
            DropForeignKey("dbo.tblOrdenesVentaDetalle", "IdProducto", "dbo.tblProductos");
            DropForeignKey("dbo.tblOrdenesVentaDetalle", "IdOrdenVenta", "dbo.tblOrdenesVenta");
            DropForeignKey("dbo.tblOrdenesVenta", "IdUser", "dbo.tblUser");
            DropForeignKey("dbo.tblUserRole", "UserId", "dbo.tblUser");
            DropForeignKey("dbo.tblUserLogin", "UserId", "dbo.tblUser");
            DropForeignKey("dbo.tblUser", "IdEstado", "dbo.tblEstados");
            DropForeignKey("dbo.tblEstados", "IdPais", "dbo.tblPaises");
            DropForeignKey("dbo.tblCiudades", "IdEstado", "dbo.tblEstados");
            DropForeignKey("dbo.tblUserClaim", "UserId", "dbo.tblUser");
            DropForeignKey("dbo.tblOrdenesVenta", "IdMetodoPago", "dbo.tblMetodosPago");
            DropForeignKey("dbo.tblOrdenesVenta", "IdMetodoEnvio", "dbo.tblMetodosEnvio");
            DropIndex("dbo.tblRole", "RoleNameIndex");
            DropIndex("dbo.tblUserRole", new[] { "RoleId" });
            DropIndex("dbo.tblUserRole", new[] { "UserId" });
            DropIndex("dbo.tblUserLogin", new[] { "UserId" });
            DropIndex("dbo.tblCiudades", new[] { "IdEstado" });
            DropIndex("dbo.tblEstados", new[] { "IdPais" });
            DropIndex("dbo.tblUserClaim", new[] { "UserId" });
            DropIndex("dbo.tblUser", "UserNameIndex");
            DropIndex("dbo.tblUser", new[] { "IdEstado" });
            DropIndex("dbo.tblOrdenesVenta", new[] { "IdUser" });
            DropIndex("dbo.tblOrdenesVenta", new[] { "IdMetodoEnvio" });
            DropIndex("dbo.tblOrdenesVenta", new[] { "IdMetodoPago" });
            DropIndex("dbo.tblOrdenesVentaDetalle", new[] { "IdProducto" });
            DropIndex("dbo.tblOrdenesVentaDetalle", new[] { "IdOrdenVenta" });
            DropIndex("dbo.tblProductos", new[] { "IdSubCategoria" });
            DropIndex("dbo.tblSubCategorias", new[] { "IdCategoria" });
            DropTable("dbo.tblMateriales");
            DropTable("dbo.tblRole");
            DropTable("dbo.tblUserRole");
            DropTable("dbo.tblUserLogin");
            DropTable("dbo.tblPaises");
            DropTable("dbo.tblCiudades");
            DropTable("dbo.tblEstados");
            DropTable("dbo.tblUserClaim");
            DropTable("dbo.tblUser");
            DropTable("dbo.tblMetodosPago");
            DropTable("dbo.tblMetodosEnvio");
            DropTable("dbo.tblOrdenesVenta");
            DropTable("dbo.tblOrdenesVentaDetalle");
            DropTable("dbo.tblProductos");
            DropTable("dbo.tblSubCategorias");
            DropTable("dbo.tblCategorias");
        }
    }
}
