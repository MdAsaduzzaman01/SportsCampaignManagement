namespace SportsManagementCampaign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1st : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BattingScoreCards",
                c => new
                    {
                        BattingScoreCardId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        BallNumber = c.Int(nullable: false),
                        Runs = c.Int(nullable: false),
                        Out = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BattingScoreCardId)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(nullable: false),
                        FatherName = c.String(nullable: false),
                        MotherName = c.String(nullable: false),
                        DateOfBirth = c.String(nullable: false),
                        BirthCertificateNumber = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        EducationalQualification = c.String(nullable: false),
                        PlayerType = c.String(nullable: false),
                        Height = c.String(nullable: false),
                        Weight = c.String(nullable: false),
                        Religion = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        HomePhone = c.String(),
                        PresentAddress = c.String(nullable: false),
                        PermanentAddress = c.String(nullable: false),
                        CampaignId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Campaigns", t => t.CampaignId, cascadeDelete: true)
                .Index(t => t.CampaignId);
            
            CreateTable(
                "dbo.BowlingScoreCards",
                c => new
                    {
                        BowlingScoreCardId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        Level = c.String(nullable: false),
                        BallNumber = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        Line = c.Int(nullable: false),
                        Speed = c.Int(nullable: false),
                        Runs = c.Int(nullable: false),
                        Wicket = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BowlingScoreCardId)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        CampaignId = c.Int(nullable: false, identity: true),
                        CampaignName = c.String(nullable: false),
                        CampaignDate = c.String(nullable: false),
                        CampaignVenue = c.String(nullable: false),
                        CampaignLevel = c.String(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CampaignId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Gender = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 14),
                        PresentAddress = c.String(nullable: false),
                        ParmanentAddress = c.String(nullable: false),
                        NID = c.String(nullable: false, maxLength: 17),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Sponsors",
                c => new
                    {
                        SponsorId = c.Int(nullable: false, identity: true),
                        CampaignId = c.Int(nullable: false),
                        CompanyName = c.String(nullable: false),
                        CompanyAddress = c.String(nullable: false),
                        AmountToPay = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.SponsorId)
                .ForeignKey("dbo.Campaigns", t => t.CampaignId, cascadeDelete: true)
                .Index(t => t.CampaignId);
            
            CreateTable(
                "dbo.FinalBattingScores",
                c => new
                    {
                        FinalBattingScoreId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        Ball1Total = c.Int(nullable: false),
                        Ball2Total = c.Int(nullable: false),
                        Ball3Total = c.Int(nullable: false),
                        Ball4Total = c.Int(nullable: false),
                        Ball5Total = c.Int(nullable: false),
                        Ball6Total = c.Int(nullable: false),
                        FinalScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FinalBattingScoreId)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.FinalBowlingScores",
                c => new
                    {
                        FinalBowlingScoreId = c.Int(nullable: false, identity: true),
                        PlayerId = c.Int(nullable: false),
                        Ball1Total = c.Int(nullable: false),
                        Ball2Total = c.Int(nullable: false),
                        Ball3Total = c.Int(nullable: false),
                        Ball4Total = c.Int(nullable: false),
                        Ball5Total = c.Int(nullable: false),
                        Ball6Total = c.Int(nullable: false),
                        FinalScore = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FinalBowlingScoreId)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.FinalBowlingScores", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.FinalBattingScores", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Sponsors", "CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.Players", "CampaignId", "dbo.Campaigns");
            DropForeignKey("dbo.Campaigns", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.BowlingScoreCards", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.BattingScoreCards", "PlayerId", "dbo.Players");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.FinalBowlingScores", new[] { "PlayerId" });
            DropIndex("dbo.FinalBattingScores", new[] { "PlayerId" });
            DropIndex("dbo.Sponsors", new[] { "CampaignId" });
            DropIndex("dbo.Campaigns", new[] { "EmployeeId" });
            DropIndex("dbo.BowlingScoreCards", new[] { "PlayerId" });
            DropIndex("dbo.Players", new[] { "CampaignId" });
            DropIndex("dbo.BattingScoreCards", new[] { "PlayerId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.FinalBowlingScores");
            DropTable("dbo.FinalBattingScores");
            DropTable("dbo.Sponsors");
            DropTable("dbo.Employees");
            DropTable("dbo.Campaigns");
            DropTable("dbo.BowlingScoreCards");
            DropTable("dbo.Players");
            DropTable("dbo.BattingScoreCards");
        }
    }
}
