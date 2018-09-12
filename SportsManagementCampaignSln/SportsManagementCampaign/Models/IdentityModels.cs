using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace SportsManagementCampaign.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SportsManagementCampaign.Models.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<SportsManagementCampaign.Models.Player> Players { get; set; }

        public System.Data.Entity.DbSet<SportsManagementCampaign.Models.Campaign> Campaigns { get; set; }

        public System.Data.Entity.DbSet<SportsManagementCampaign.Models.Sponsor> Sponsors { get; set; }

        public System.Data.Entity.DbSet<SportsManagementCampaign.Models.BowlingScoreCard> BowlingScoreCards { get; set; }

        public System.Data.Entity.DbSet<SportsManagementCampaign.Models.BattingScoreCard> BattingScoreCards { get; set; }

        public System.Data.Entity.DbSet<SportsManagementCampaign.Models.FinalBattingScore> FinalBattingScores { get; set; }

        public System.Data.Entity.DbSet<SportsManagementCampaign.Models.FinalBowlingScore> FinalBowlingScores { get; set; }

        public System.Data.Entity.DbSet<SportsManagementCampaign.Models.Subscribe> Subscribes { get; set; }

        public System.Data.Entity.DbSet<SportsManagementCampaign.Models.Contact> Contacts { get; set; }

        public System.Data.Entity.DbSet<SportsManagementCampaign.Models.UserDetails> UserDetails { get; set; }

        //public System.Data.Entity.DbSet<SportsManagementCampaign.ViewModels.PlayerFinalAlrounder> PlayerFinalAlrounders { get; set; }

        //public System.Data.Entity.DbSet<SportsManagementCampaign.ViewModels.PlayerFinalBowling> PlayerFinalBowlings { get; set; }

        //public System.Data.Entity.DbSet<SportsManagementCampaign.ViewModels.PlayerFinalBatting> PlayerFinalBattings { get; set; }
    }
}