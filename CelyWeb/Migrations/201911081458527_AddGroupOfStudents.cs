namespace CelyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroupOfStudents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupOfStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PaymentTypeId = c.Int(nullable: false),
                        IsVIP = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GroupOfStudents");
        }
    }
}
