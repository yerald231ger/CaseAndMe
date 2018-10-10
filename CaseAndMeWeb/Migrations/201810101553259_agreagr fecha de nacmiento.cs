namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agreagrfechadenacmiento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblUser", "FechaNacimiento", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblUser", "FechaNacimiento");
        }
    }
}
