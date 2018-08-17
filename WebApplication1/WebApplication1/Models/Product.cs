using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Display (Name = "Product Name")]
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool MembershipType { get; set; }
    }
}