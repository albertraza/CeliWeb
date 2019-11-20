namespace CelyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsVIPAndIsForGroupsToPaymentTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentTypes", "IsVIP", c => c.Boolean(nullable: false));
            AddColumn("dbo.PaymentTypes", "IsForGroups", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PaymentTypes", "IsForGroups");
            DropColumn("dbo.PaymentTypes", "IsVIP");
        }
    }
}
