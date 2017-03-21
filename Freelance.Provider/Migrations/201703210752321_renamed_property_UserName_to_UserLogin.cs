namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamed_property_UserName_to_UserLogin : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.User", name: "UserName", newName: "UserLogin");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.User", name: "UserLogin", newName: "UserName");
        }
    }
}
