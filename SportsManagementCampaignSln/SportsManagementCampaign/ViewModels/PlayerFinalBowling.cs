using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsManagementCampaign.ViewModels
{
    public class PlayerFinalBowling
    {
        [Key]
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string PlayerType { get; set; }

        public string CampaignVenue { get; set; }
        public string CampaignDate { get; set; }
        public string CampaignLevel { get; set; }

        public int Ball1Total { get; set; }
        public int Ball2Total { get; set; }
        public int Ball3Total { get; set; }
        public int Ball4Total { get; set; }
        public int Ball5Total { get; set; }
        public int Ball6Total { get; set; }
        public int FinalScore { get; set; }
        public int CampaignId { get; set; }
        public int FinalBowlingScoreId { get; set; }

    }
}