using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Dto
{
    public class ProductDto
    {

            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int Price { get; set; }
            public string Description { get; set; }
            public bool MembershipType { get; set; }
       
    }
}