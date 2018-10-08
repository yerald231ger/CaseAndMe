namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion_Eduardo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblUser", "Nombre", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblUser", "Nombre", c => c.String());
        }
    }
}
