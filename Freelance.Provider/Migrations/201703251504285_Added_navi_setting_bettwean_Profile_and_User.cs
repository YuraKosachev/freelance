namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_navi_setting_bettwean_Profile_and_User : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profiles", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Profiles", "UserId");
            AddForeignKey("dbo.Profiles", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "UserId", "dbo.User");
            DropIndex("dbo.Profiles", new[] { "UserId" });
            AlterColumn("dbo.Profiles", "UserId", c => c.String());
        }
    }
}
