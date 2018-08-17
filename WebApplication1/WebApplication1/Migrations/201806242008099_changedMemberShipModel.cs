namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedMemberShipModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "DiscountRate", c => c.Int(nullable: false));
            DropColumn("dbo.MembershipTypes", "IsSubscribed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "IsSubscribed", c => c.Boolean(nullable: false));
            DropColumn("dbo.MembershipTypes", "DiscountRate");
        }
    }
}
