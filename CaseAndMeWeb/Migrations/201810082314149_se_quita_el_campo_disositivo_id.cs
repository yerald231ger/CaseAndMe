namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class se_quita_el_campo_disositivo_id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblOrdenesVentaDetalle", "Dispositivo_Id", "dbo.tblDispositivo");
            DropIndex("dbo.tblOrdenesVentaDetalle", new[] { "Dispositivo_Id" });
            DropColumn("dbo.tblOrdenesVentaDetalle", "idDipositivo");
            RenameColumn(table: "dbo.tblOrdenesVentaDetalle", name: "Dispositivo_Id", newName: "IdDipositivo");
            AlterColumn("dbo.tblOrdenesVentaDetalle", "IdDipositivo", c => c.Int(nullable: false));
            AlterColumn("dbo.tblUser", "Nombre", c => c.String());
            CreateIndex("dbo.tblOrdenesVentaDetalle", "IdDipositivo");
            AddForeignKey("dbo.tblOrdenesVentaDetalle", "IdDipositivo", "dbo.tblDispositivo", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblOrdenesVentaDetalle", "IdDipositivo", "dbo.tblDispositivo");
            DropIndex("dbo.tblOrdenesVentaDetalle", new[] { "IdDipositivo" });
            AlterColumn("dbo.tblUser", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.tblOrdenesVentaDetalle", "IdDipositivo", c => c.Int());
            RenameColumn(table: "dbo.tblOrdenesVentaDetalle", name: "IdDipositivo", newName: "Dispositivo_Id");
            AddColumn("dbo.tblOrdenesVentaDetalle", "idDipositivo", c => c.Int(nullable: false));
            CreateIndex("dbo.tblOrdenesVentaDetalle", "Dispositivo_Id");
            AddForeignKey("dbo.tblOrdenesVentaDetalle", "Dispositivo_Id", "dbo.tblDispositivo", "Id");
        }
    }
}
