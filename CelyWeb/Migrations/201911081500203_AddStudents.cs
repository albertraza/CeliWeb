namespace CelyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStudents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        LastPaymentDate = c.DateTime(),
                        SeccionId = c.Int(nullable: false),
                        PaymentTypeId = c.Int(nullable: false),
                        IsDelinquent = c.Boolean(nullable: false),
                        IsVIP = c.Boolean(nullable: false),
                        GroupOfStudentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
