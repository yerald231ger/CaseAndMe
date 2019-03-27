namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Martin190317 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblDispositivo", "Mascaras", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblDispositivo", "Mascaras");
        }
    }
}
