using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsManagementCampaign.Models
{
    public class BowlingScoreCard
    {
        public int BowlingScoreCardId { get; set; }

        [Required(ErrorMessage = "Select player Id")]
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "Select Level")]
        public string Level { get; set; }

        [Required(ErrorMessage = "Select Ball No.")]
        public int BallNumber { get; set; }

        [Required(ErrorMessage = "Select Ball Length")]
        public int Length { get; set; }

        [Required(ErrorMessage = "Select Ball Line")]
        public int Line { get; set; }

        [Required(ErrorMessage = "Select Ball Speed")]
        public int Speed { get; set; }

        [Required(ErrorMessage = "Enter Runs")]
        public int Runs { get; set; }

        [Required(ErrorMessage = "Select Wicket")]
        public int Wicket { get; set; }

        public int Total { get; set; }

        public virtual Player Player { get; set; }
    }
}