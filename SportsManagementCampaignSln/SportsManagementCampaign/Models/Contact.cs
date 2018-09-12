using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsManagementCampaign.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage ="Subject required")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Enter Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email Address Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Message { get; set; }
    }
}