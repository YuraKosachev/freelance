namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customazing_User_added_setting_UserSurname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserSurname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserSurname");
        }
    }
}
