namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO MembershipTypes (Name, DiscountRate) VALUES ('Pay Monthly', 20);
                  INSERT INTO MembershipTypes (Name, DiscountRate) VALUES ('One-off Payment', 10);");
        }
        
        public override void Down()
        {
        }
    }
}
