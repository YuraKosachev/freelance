namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_attr_for_dbo_Profile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "UserId", "dbo.User");
            DropIndex("dbo.Profiles", new[] { "UserId" });
            AlterColumn("dbo.Profiles", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Profiles", "UserId");
            AddForeignKey("dbo.Profiles", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "UserId", "dbo.User");
            DropIndex("dbo.Profiles", new[] { "UserId" });
            AlterColumn("dbo.Profiles", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Profiles", "UserId");
            AddForeignKey("dbo.Profiles", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
    }
}
