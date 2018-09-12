using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsManagementCampaign.ViewModels
{
    public class PlayerFinalAlrounder
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

        public int BattingFinalScore { get; set; }
        public int BowlingFinalScore { get; set; }
        public int TotalScore { get; set; }
        public int CampaignId { get; set; }
        public int FinalBattingScoreId { get; set; }
        public int FinalBowlingScoreId { get; set; }
    }
}