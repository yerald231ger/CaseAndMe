namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion_Eduardo_1809221314 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblDispositivo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaMod = c.DateTime(nullable: false),
                        FechaAlt = c.DateTime(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblDispositivo");
        }
    }
}
