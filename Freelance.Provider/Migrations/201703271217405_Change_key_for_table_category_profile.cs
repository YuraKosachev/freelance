namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_key_for_table_category_profile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "UserId", "dbo.User");
            DropIndex("dbo.Profiles", new[] { "UserId" });
            AddColumn("dbo.Profiles", "CategoryId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Profiles", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Profiles", "UserId");
            AddForeignKey("dbo.Profiles", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "UserId", "dbo.User");
            DropIndex("dbo.Profiles", new[] { "UserId" });
            AlterColumn("dbo.Profiles", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.Profiles", "CategoryId");
            CreateIndex("dbo.Profiles", "UserId");
            AddForeignKey("dbo.Profiles", "UserId", "dbo.User", "Id");
        }
    }
}
