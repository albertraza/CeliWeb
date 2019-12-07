namespace CelyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNullableToNonNullableInt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "GroupOfStudentId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "GroupOfStudentId", c => c.Int());
        }
    }
}
