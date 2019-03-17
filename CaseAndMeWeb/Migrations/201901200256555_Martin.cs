namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Martin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblDispositivo", "Marca", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblDispositivo", "Marca");
        }
    }
}
