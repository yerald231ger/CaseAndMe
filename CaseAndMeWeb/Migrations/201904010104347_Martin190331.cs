namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Martin190331 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblOrdenesVentaDetalle", "isCustom", c => c.Boolean(nullable: false));
            AddColumn("dbo.tblOrdenesVentaDetalle", "Imagen", c => c.String());
            AddColumn("dbo.tblOrdenesVenta", "Nombre", c => c.String());
            AddColumn("dbo.tblOrdenesVenta", "Apellido", c => c.String());
            AddColumn("dbo.tblOrdenesVenta", "CP", c => c.String());
            AddColumn("dbo.tblOrdenesVenta", "Ciudad", c => c.String());
            AddColumn("dbo.tblOrdenesVenta", "Colonia", c => c.String());
            AddColumn("dbo.tblOrdenesVenta", "Direccion", c => c.String());
            AddColumn("dbo.tblOrdenesVenta", "Email", c => c.String());
            AddColumn("dbo.tblOrdenesVenta", "Estado", c => c.String());
            AddColumn("dbo.tblOrdenesVenta", "Pais", c => c.String());
            AddColumn("dbo.tblOrdenesVenta", "Telefono", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblOrdenesVenta", "Telefono");
            DropColumn("dbo.tblOrdenesVenta", "Pais");
            DropColumn("dbo.tblOrdenesVenta", "Estado");
            DropColumn("dbo.tblOrdenesVenta", "Email");
            DropColumn("dbo.tblOrdenesVenta", "Direccion");
            DropColumn("dbo.tblOrdenesVenta", "Colonia");
            DropColumn("dbo.tblOrdenesVenta", "Ciudad");
            DropColumn("dbo.tblOrdenesVenta", "CP");
            DropColumn("dbo.tblOrdenesVenta", "Apellido");
            DropColumn("dbo.tblOrdenesVenta", "Nombre");
            DropColumn("dbo.tblOrdenesVentaDetalle", "Imagen");
            DropColumn("dbo.tblOrdenesVentaDetalle", "isCustom");
        }
    }
}
