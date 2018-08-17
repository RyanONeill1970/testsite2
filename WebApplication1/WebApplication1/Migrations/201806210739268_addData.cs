namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addData : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Customers(CustomerName, CustomerAge) VALUES('Ramesh', 32);
INSERT INTO Customers(CustomerName, CustomerAge) VALUES('Barry', 12);
INSERT INTO Customers(CustomerName, CustomerAge) VALUES('Gary', 54);
INSERT INTO Customers(CustomerName, CustomerAge) VALUES('Will', 28);
INSERT INTO Customers(CustomerName, CustomerAge) VALUES('James', 21)");


        }


        
        public override void Down()
        {
        }
    }
}
