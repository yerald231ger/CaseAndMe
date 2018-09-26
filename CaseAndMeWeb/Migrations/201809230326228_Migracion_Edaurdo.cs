namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion_Edaurdo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblProductos", "Codigo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblProductos", "Codigo");
        }
    }
}
