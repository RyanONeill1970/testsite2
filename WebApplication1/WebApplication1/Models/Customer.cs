using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Display (Name = "Date of Birth")]
        [min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        [Required]
        [Display (Name = "Customer Name")]
        public string CustomerName { get; set; }

        public string CustomerAdditionalDetails { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }
    }
}