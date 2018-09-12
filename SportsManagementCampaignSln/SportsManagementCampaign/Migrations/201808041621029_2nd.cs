namespace SportsManagementCampaign.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2nd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.Subscribes",
                c => new
                    {
                        SubscribeId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.SubscribeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Subscribes");
            DropTable("dbo.Contacts");
        }
    }
}
