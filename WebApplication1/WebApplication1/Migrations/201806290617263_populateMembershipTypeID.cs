namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembershipTypeID : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE Customers SET MembershipTypeID = '1' WHERE CustomerId = '1';");
        }
        
        public override void Down()
        {
        }
    }
}
