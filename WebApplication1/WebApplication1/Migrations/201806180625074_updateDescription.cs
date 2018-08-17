namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDescription : DbMigration
    {
        public override void Up()
        {
            Sql(@"UPDATE Products SET Description = 'The greatest headphones' WHERE ProductID = '2'");
        }
        
        public override void Down()
        {
        }
    }
}