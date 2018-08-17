namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesToDomainModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Birthdate", c => c.DateTime());
            DropColumn("dbo.Customers", "CustomerAge");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomerAge", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "Birthdate");
        }
    }
}
