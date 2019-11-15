namespace CelyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedInterfacesforTypeImplementations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "GroupOfStudents_Id", c => c.Int());
            CreateIndex("dbo.Students", "SeccionId");
            CreateIndex("dbo.Students", "PaymentTypeId");
            CreateIndex("dbo.Students", "GroupOfStudents_Id");
            AddForeignKey("dbo.Students", "GroupOfStudents_Id", "dbo.GroupOfStudents", "Id");
            AddForeignKey("dbo.Students", "PaymentTypeId", "dbo.PaymentTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "SeccionId", "dbo.Seccions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "SeccionId", "dbo.Seccions");
            DropForeignKey("dbo.Students", "PaymentTypeId", "dbo.PaymentTypes");
            DropForeignKey("dbo.Students", "GroupOfStudents_Id", "dbo.GroupOfStudents");
            DropIndex("dbo.Students", new[] { "GroupOfStudents_Id" });
            DropIndex("dbo.Students", new[] { "PaymentTypeId" });
            DropIndex("dbo.Students", new[] { "SeccionId" });
            DropColumn("dbo.Students", "GroupOfStudents_Id");
        }
    }
}
