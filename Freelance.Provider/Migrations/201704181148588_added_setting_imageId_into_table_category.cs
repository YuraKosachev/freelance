namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_setting_imageId_into_table_category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ImageId", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ImageId");
        }
    }
}
