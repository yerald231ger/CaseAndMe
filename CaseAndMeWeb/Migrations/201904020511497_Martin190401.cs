namespace CaseAndMeWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Martin190401 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblBitacoraError",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Metodo = c.String(),
                        Descripcion = c.String(),
                        FechaMod = c.DateTime(nullable: false),
                        FechaAlt = c.DateTime(nullable: false),
                        EsActivo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblBitacoraError");
        }
    }
}
