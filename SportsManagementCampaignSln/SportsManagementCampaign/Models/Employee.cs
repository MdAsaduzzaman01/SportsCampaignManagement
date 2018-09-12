using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsManagementCampaign.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Select Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Phone Number")]
        [Phone]
        [StringLength(14)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter Present Address")]
        public string PresentAddress { get; set; }

        [Required(ErrorMessage = "Enter Parmanent Address")]
        public string ParmanentAddress { get; set; }

        [Required(ErrorMessage = "Enter NID Number")]
        [StringLength(17)]
        public string NID { get; set; }

        public virtual ICollection<Campaign> Campaigns { get; set; }
    }
}