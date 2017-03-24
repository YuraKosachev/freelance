namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_name_key_in_Category : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Categories");
            AddColumn("dbo.Categories", "Id", c => c.Guid(nullable: false,identity:true));
            AddPrimaryKey("dbo.Categories", "Id");
            DropColumn("dbo.Categories", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "CategoryId", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.Categories");
            DropColumn("dbo.Categories", "Id");
            AddPrimaryKey("dbo.Categories", "CategoryId");
        }
    }
}
