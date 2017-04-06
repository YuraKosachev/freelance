namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK_to_table_category : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "Id", "dbo.Categories");
            DropIndex("dbo.Profiles", new[] { "Id" });
            AddColumn("dbo.Profiles", "CategoryId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Profiles", "CategoryId");
            AddForeignKey("dbo.Profiles", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Profiles", new[] { "CategoryId" });
            DropColumn("dbo.Profiles", "CategoryId");
            CreateIndex("dbo.Profiles", "Id");
            AddForeignKey("dbo.Profiles", "Id", "dbo.Categories", "Id");
        }
    }
}
