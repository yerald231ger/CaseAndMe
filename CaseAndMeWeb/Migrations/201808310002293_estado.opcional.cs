namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class estadoopcional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tblUser", "IdEstado", "dbo.tblEstados");
            DropIndex("dbo.tblUser", new[] { "IdEstado" });
            AddColumn("dbo.tblUser", "Estado_Id", c => c.Int());
            CreateIndex("dbo.tblUser", "Estado_Id");
            AddForeignKey("dbo.tblUser", "Estado_Id", "dbo.tblEstados", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUser", "Estado_Id", "dbo.tblEstados");
            DropIndex("dbo.tblUser", new[] { "Estado_Id" });
            DropColumn("dbo.tblUser", "Estado_Id");
            CreateIndex("dbo.tblUser", "IdEstado");
            AddForeignKey("dbo.tblUser", "IdEstado", "dbo.tblEstados", "Id", cascadeDelete: true);
        }
    }
}
