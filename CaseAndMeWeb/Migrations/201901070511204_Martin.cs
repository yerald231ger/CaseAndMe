namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Martin : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblInventario", "Producto_Id", "dbo.tblProductos");
            DropForeignKey("dbo.tblOrdenesVentaDetalle", "IdProducto", "dbo.tblProductos");
            DropIndex("dbo.tblInventario", new[] { "Producto_Id" });
            DropColumn("dbo.tblProductos", "Id");
            RenameColumn(table: "dbo.tblProductos", name: "Producto_Id", newName: "Id");
            DropPrimaryKey("dbo.tblProductos");
            AlterColumn("dbo.tblProductos", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.tblProductos", "Id");
            CreateIndex("dbo.tblProductos", "Id");
            AddForeignKey("dbo.tblOrdenesVentaDetalle", "IdProducto", "dbo.tblProductos", "Id", cascadeDelete: true);
            DropColumn("dbo.tblInventario", "Producto_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblInventario", "Producto_Id", c => c.Int());
            DropForeignKey("dbo.tblOrdenesVentaDetalle", "IdProducto", "dbo.tblProductos");
            DropIndex("dbo.tblProductos", new[] { "Id" });
            DropPrimaryKey("dbo.tblProductos");
            AlterColumn("dbo.tblProductos", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.tblProductos", "Id");
            RenameColumn(table: "dbo.tblProductos", name: "Id", newName: "Producto_Id");
            AddColumn("dbo.tblProductos", "Id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.tblInventario", "Producto_Id");
            AddForeignKey("dbo.tblOrdenesVentaDetalle", "IdProducto", "dbo.tblProductos", "Id", cascadeDelete: true);
            AddForeignKey("dbo.tblInventario", "Producto_Id", "dbo.tblProductos", "Id");
        }
    }
}
