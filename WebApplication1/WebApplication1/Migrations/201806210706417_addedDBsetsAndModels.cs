namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDBsetsAndModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerAge = c.Int(nullable: false),
                        CustomerName = c.String(),
                        CustomerAdditionalDetails = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        MembershipID = c.Int(nullable: false, identity: true),
                        IsSubscribed = c.Boolean(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.MembershipID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MembershipTypes");
            DropTable("dbo.Customers");
        }
    }
}
