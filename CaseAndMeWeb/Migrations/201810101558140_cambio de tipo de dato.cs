namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiodetipodedato : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblUser", "FechaNacimiento", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblUser", "FechaNacimiento", c => c.DateTime());
        }
    }
}
