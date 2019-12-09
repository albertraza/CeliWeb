namespace CelyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDependencyForIPaymentTypes : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.GroupOfStudents", "PaymentTypeId");
            AddForeignKey("dbo.GroupOfStudents", "PaymentTypeId", "dbo.PaymentTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupOfStudents", "PaymentTypeId", "dbo.PaymentTypes");
            DropIndex("dbo.GroupOfStudents", new[] { "PaymentTypeId" });
        }
    }
}
