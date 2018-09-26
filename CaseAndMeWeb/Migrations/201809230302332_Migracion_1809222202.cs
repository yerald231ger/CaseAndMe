namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion_1809222202 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblOrdenesVentaDetalle", "idDipositivo", c => c.Int(nullable: false));
            AddColumn("dbo.tblOrdenesVentaDetalle", "Dispositivo_Id", c => c.Int());
            CreateIndex("dbo.tblOrdenesVentaDetalle", "Dispositivo_Id");
            AddForeignKey("dbo.tblOrdenesVentaDetalle", "Dispositivo_Id", "dbo.tblDispositivo", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblOrdenesVentaDetalle", "Dispositivo_Id", "dbo.tblDispositivo");
            DropIndex("dbo.tblOrdenesVentaDetalle", new[] { "Dispositivo_Id" });
            DropColumn("dbo.tblOrdenesVentaDetalle", "Dispositivo_Id");
            DropColumn("dbo.tblOrdenesVentaDetalle", "idDipositivo");
        }
    }
}
