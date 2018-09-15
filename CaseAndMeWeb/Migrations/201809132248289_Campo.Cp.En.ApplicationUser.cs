namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoCpEnApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblUser", "Nombre", c => c.String());
            AddColumn("dbo.tblUser", "CP", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblUser", "CP");
            DropColumn("dbo.tblUser", "Nombre");
        }
    }
}
