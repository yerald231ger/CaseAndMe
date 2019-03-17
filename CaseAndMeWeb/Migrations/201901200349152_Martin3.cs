namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Martin3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblMateriales", "imagen", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblMateriales", "imagen");
        }
    }
}
