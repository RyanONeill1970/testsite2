using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1
{
    public class dbgeneration : DbContext
    {

        public DbSet<Product> GetProducts { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Customer> GetCustomers { get; set; }
       
    }
}