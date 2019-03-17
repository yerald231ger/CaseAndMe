namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Martin2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblMateriales", "Colores", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblMateriales", "Colores");
        }
    }
}
