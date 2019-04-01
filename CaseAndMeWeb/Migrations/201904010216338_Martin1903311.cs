namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Martin1903311 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblOrdenesVentaDetalle", "IdMaterial", c => c.Int(nullable: false));
            AddColumn("dbo.tblOrdenesVentaDetalle", "Precio", c => c.Double(nullable: false));
            AddColumn("dbo.tblOrdenesVentaDetalle", "Material_Id", c => c.Int());
            CreateIndex("dbo.tblOrdenesVentaDetalle", "Material_Id");
            AddForeignKey("dbo.tblOrdenesVentaDetalle", "Material_Id", "dbo.tblMateriales", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblOrdenesVentaDetalle", "Material_Id", "dbo.tblMateriales");
            DropIndex("dbo.tblOrdenesVentaDetalle", new[] { "Material_Id" });
            DropColumn("dbo.tblOrdenesVentaDetalle", "Material_Id");
            DropColumn("dbo.tblOrdenesVentaDetalle", "Precio");
            DropColumn("dbo.tblOrdenesVentaDetalle", "IdMaterial");
        }
    }
}
