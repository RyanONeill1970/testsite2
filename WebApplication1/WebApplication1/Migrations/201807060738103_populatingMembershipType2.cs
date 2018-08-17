namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatingMembershipType2 : DbMigration
    {
        public override void Up()
        {

            Sql(@"UPDATE Customers SET MembershipType_MembershipID = '1' WHERE CustomerId = '6';");
            Sql(@"UPDATE Customers SET MembershipType_MembershipID = '2' WHERE CustomerId = '7';");
            Sql(@"UPDATE Customers SET MembershipType_MembershipID = '1' WHERE CustomerId = '8';");
                }
        
        public override void Down()
        {
        }
    }
}
