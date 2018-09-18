namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eliminarelestadoid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblUser", "Estado_Id", "dbo.tblEstados");
            DropIndex("dbo.tblUser", new[] { "Estado_Id" });
            DropColumn("dbo.tblUser", "IdEstado");
            RenameColumn(table: "dbo.tblUser", name: "Estado_Id", newName: "IdEstado");
            AlterColumn("dbo.tblUser", "IdEstado", c => c.Int(nullable: false));
            CreateIndex("dbo.tblUser", "IdEstado");
            AddForeignKey("dbo.tblUser", "IdEstado", "dbo.tblEstados", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUser", "IdEstado", "dbo.tblEstados");
            DropIndex("dbo.tblUser", new[] { "IdEstado" });
            AlterColumn("dbo.tblUser", "IdEstado", c => c.Int());
            RenameColumn(table: "dbo.tblUser", name: "IdEstado", newName: "Estado_Id");
            AddColumn("dbo.tblUser", "IdEstado", c => c.Int(nullable: false));
            CreateIndex("dbo.tblUser", "Estado_Id");
            AddForeignKey("dbo.tblUser", "Estado_Id", "dbo.tblEstados", "Id");
        }
    }
}
