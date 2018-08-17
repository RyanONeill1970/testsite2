using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto
{
    public class CustomerDto
    {

        
            public int CustomerId { get; set; }

           // [min18YearsIfAMember]
            public DateTime? Birthdate { get; set; }

            [Required]
            public string CustomerName { get; set; }

            public string CustomerAdditionalDetails { get; set; }

            public bool IsSubscribedToNewsletter { get; set; }

            public int MembershipTypeId { get; set; }
        

    }
}