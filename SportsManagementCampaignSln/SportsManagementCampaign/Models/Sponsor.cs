using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsManagementCampaign.Models
{
    public class Sponsor
    {
        public int SponsorId { get; set; }

        [Required(ErrorMessage = "Select Campaign ")]
        public int CampaignId { get; set; }

        [Required(ErrorMessage = "Enter Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Enter Company Address")]
        public string CompanyAddress { get; set; }

        [Required(ErrorMessage = "Enter Amount")]
        public double AmountToPay { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}