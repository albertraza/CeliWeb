namespace CelyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeccion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Seccions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nivel = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        Aula = c.String(),
                        StudentLimit = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Seccions");
        }
    }
}
