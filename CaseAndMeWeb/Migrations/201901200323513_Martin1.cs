namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Martin1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblMateriales", "Descripcion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblMateriales", "Descripcion");
        }
    }
}
