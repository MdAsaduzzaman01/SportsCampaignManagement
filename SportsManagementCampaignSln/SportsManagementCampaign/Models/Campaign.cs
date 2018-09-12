using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsManagementCampaign.Models
{
    public class Campaign
    {
        public int CampaignId { get; set; }

        [Required(ErrorMessage = "Enter Campaign Name")]
        public string CampaignName { get; set; }

        [Required(ErrorMessage = "Enter Campaign Date")]
        public string CampaignDate { get; set; }

        [Required(ErrorMessage = "Enter Campaign Venue")]
        public string CampaignVenue { get; set; }

        [Required(ErrorMessage = "Select Campaign Level")]
        public string CampaignLevel { get; set; }

        [Required(ErrorMessage = "Enter Employee Id")]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Sponsor> Sponsors { get; set; }
    }
}