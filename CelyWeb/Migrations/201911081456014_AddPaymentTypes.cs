namespace CelyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAdded = c.DateTime(nullable: false),
                        Type = c.String(nullable: false),
                        Amount = c.Double(nullable: false),
                        DaysToPay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentTypes");
        }
    }
}
