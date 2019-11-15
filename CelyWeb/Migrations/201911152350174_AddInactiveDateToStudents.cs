namespace CelyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInactiveDateToStudents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "InactiveDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "InactiveDate");
        }
    }
}
