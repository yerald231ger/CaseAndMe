namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Martin20190325 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblMateriales", "precio", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblMateriales", "precio");
        }
    }
}
