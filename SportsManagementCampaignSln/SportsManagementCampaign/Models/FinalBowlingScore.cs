using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsManagementCampaign.Models
{
    public class FinalBowlingScore
    {
        public int FinalBowlingScoreId { get; set; }

        [Required(ErrorMessage = "Enter Player Id")]
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "Select Ball Number / PlayerId")]
        public int Ball1Total { get; set; }

        [Required(ErrorMessage = "Select Ball Number / PlayerId")]
        public int Ball2Total { get; set; }

        [Required(ErrorMessage = "Select Ball Number / PlayerId")]
        public int Ball3Total { get; set; }

        [Required(ErrorMessage = "Select Ball Number / PlayerId")]
        public int Ball4Total { get; set; }

        [Required(ErrorMessage = "Select Ball Number / PlayerId")]
        public int Ball5Total { get; set; }

        [Required(ErrorMessage = "Select Ball Number / PlayerId")]
        public int Ball6Total { get; set; }

        [Required(ErrorMessage = "Select Ball Number / PlayerId")]
        public int FinalScore { get; set; }


        public virtual Player Player { get; set; }
    }
}