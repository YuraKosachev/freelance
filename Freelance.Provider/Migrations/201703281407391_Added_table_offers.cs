namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_table_offers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OfferProfiles",
                c => new
                    {
                        Offer_Id = c.Guid(nullable: false),
                        Profile_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Offer_Id, t.Profile_Id })
                .ForeignKey("dbo.Offers", t => t.Offer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id, cascadeDelete: true)
                .Index(t => t.Offer_Id)
                .Index(t => t.Profile_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfferProfiles", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.OfferProfiles", "Offer_Id", "dbo.Offers");
            DropIndex("dbo.OfferProfiles", new[] { "Profile_Id" });
            DropIndex("dbo.OfferProfiles", new[] { "Offer_Id" });
            DropTable("dbo.OfferProfiles");
            DropTable("dbo.Offers");
        }
    }
}
