using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsManagementCampaign.Models
{
    public class Player
    {
        public int PlayerId { get; set; }

        [Required(ErrorMessage = "Enter Player Name")]
        public string PlayerName { get; set; }

        [Required(ErrorMessage = "Enter Father Name")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Enter Mother Name")]
        public string MotherName { get; set; }

        [Required(ErrorMessage = "Enter Date of Birth")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "Enter Birth Certificate Number")]
        public string BirthCertificateNumber { get; set; }

        [Required(ErrorMessage = "Enter Age")]
        [Range(12, 16, ErrorMessage = "Age must be between 12 to 16")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter  Education Qualification")]
        public string EducationalQualification { get; set; }

        [Required(ErrorMessage = "Select Player type ")]
        public string PlayerType { get; set; }

        [Required(ErrorMessage = "Enter Height")]
        public string Height { get; set; }

        [Required(ErrorMessage = "Enter Weight")]
        public string Weight { get; set; }

        [Required(ErrorMessage = "Select Religion")]
        public string Religion { get; set; }

        [Required(ErrorMessage = "Enter Phone")]
        public string Phone { get; set; }

        public string HomePhone { get; set; }

        [Required(ErrorMessage = "Enter Present Address")]
        public string PresentAddress { get; set; }

        [Required(ErrorMessage = "Enter Permanent Address")]
        public string PermanentAddress { get; set; }

        [Required(ErrorMessage = "Select Campaign")]
        public int CampaignId { get; set; }

        public virtual Campaign Campaign { get; set; }
        public virtual ICollection<BowlingScoreCard> BowlingScoreCards { get; set; }
        public virtual ICollection<BattingScoreCard> BattingScoreCards { get; set; }
        public virtual ICollection<FinalBattingScore> FinalBattingScores { get; set; }
        public virtual ICollection<FinalBowlingScore> FinalBowlingScores { get; set; }

    }
}