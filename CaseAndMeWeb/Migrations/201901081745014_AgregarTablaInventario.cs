namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarTablaInventario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblInventario",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Nombre = c.String(),
                        FechaMod = c.DateTime(nullable: false),
                        FechaAlt = c.DateTime(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblProductos", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblInventario", "Id", "dbo.tblProductos");
            DropIndex("dbo.tblInventario", new[] { "Id" });
            DropTable("dbo.tblInventario");
        }
    }
}
