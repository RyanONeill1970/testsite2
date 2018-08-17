namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCustomerProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "MembershipType_MembershipID", c => c.Int());
            AddColumn("dbo.Products", "MembershipType", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Customers", "MembershipType_MembershipID");
            AddForeignKey("dbo.Customers", "MembershipType_MembershipID", "dbo.MembershipTypes", "MembershipID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipType_MembershipID", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_MembershipID" });
            DropColumn("dbo.Products", "MembershipType");
            DropColumn("dbo.Customers", "MembershipType_MembershipID");
            DropColumn("dbo.Customers", "MembershipTypeId");
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
        }
    }
}
