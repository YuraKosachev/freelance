namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_key : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Profiles", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "CategoryId", c => c.Guid(nullable: false));
        }
    }
}
