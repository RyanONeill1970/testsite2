namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO MembershipTypes (Name, DiscountRate) VALUES ('Monthly Payment', 25)");
        }
        
        public override void Down()
        {
        }
    }
}
