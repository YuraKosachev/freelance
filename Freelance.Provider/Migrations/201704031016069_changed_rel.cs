namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed_rel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OfferProfiles", "Offer_Id", "dbo.Offers");
            DropForeignKey("dbo.OfferProfiles", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.OfferProfiles", new[] { "Offer_Id" });
            DropIndex("dbo.OfferProfiles", new[] { "Profile_Id" });
            AddColumn("dbo.Offers", "ProfileId", c => c.Guid(nullable: false));
            AddColumn("dbo.Offers", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Offers", "ProfileId");
            CreateIndex("dbo.Offers", "UserId");
            AddForeignKey("dbo.Offers", "ProfileId", "dbo.Profiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Offers", "UserId", "dbo.User", "Id");
            DropTable("dbo.OfferProfiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OfferProfiles",
                c => new
                    {
                        Offer_Id = c.Guid(nullable: false),
                        Profile_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Offer_Id, t.Profile_Id });
            
            DropForeignKey("dbo.Offers", "UserId", "dbo.User");
            DropForeignKey("dbo.Offers", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.Offers", new[] { "UserId" });
            DropIndex("dbo.Offers", new[] { "ProfileId" });
            DropColumn("dbo.Offers", "UserId");
            DropColumn("dbo.Offers", "ProfileId");
            CreateIndex("dbo.OfferProfiles", "Profile_Id");
            CreateIndex("dbo.OfferProfiles", "Offer_Id");
            AddForeignKey("dbo.OfferProfiles", "Profile_Id", "dbo.Profiles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OfferProfiles", "Offer_Id", "dbo.Offers", "Id", cascadeDelete: true);
        }
    }
}
