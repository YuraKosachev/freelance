namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_setting_imageId_into_table_user : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "ImageId", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "ImageId");
        }
    }
}
