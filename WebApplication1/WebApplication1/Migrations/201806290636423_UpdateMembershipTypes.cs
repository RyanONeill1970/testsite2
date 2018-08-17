namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "CustomerName", c => c.String(nullable: false));
            Sql(@"UPDATE Customers SET MembershipType_MembershipID = '1' WHERE CustomerId = '1';");
            Sql(@"UPDATE Customers SET MembershipType_MembershipID = '2' WHERE CustomerId = '2';");
            Sql(@"UPDATE Customers SET MembershipType_MembershipID = '1' WHERE CustomerId = '3';");
            Sql(@"UPDATE Customers SET MembershipType_MembershipID = '3' WHERE CustomerId = '4';");
            Sql(@"UPDATE Customers SET MembershipType_MembershipID = '2' WHERE CustomerId = '5';");

        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CustomerName", c => c.String());
        }
    }
}
