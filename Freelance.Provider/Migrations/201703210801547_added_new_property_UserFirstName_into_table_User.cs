namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_new_property_UserFirstName_into_table_User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "UserFirstName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "UserFirstName");
        }
    }
}
