using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsManagementCampaign.Models
{
    public class BattingScoreCard
    {
        public int BattingScoreCardId { get; set; }

        [Required(ErrorMessage = "Select Player Id")]
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "Select Ball Number")]
        public int BallNumber { get; set; }

        [Required(ErrorMessage = "Enter Runs")]
        public int Runs { get; set; }

        [Required(ErrorMessage = "Select Out Status")]
        public int Out { get; set; }

        public int Total { get; set; }

        public virtual Player Player { get; set; }
    }
}