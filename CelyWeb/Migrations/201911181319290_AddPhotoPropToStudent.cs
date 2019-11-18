namespace CelyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhotoPropToStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Photo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Photo");
        }
    }
}
