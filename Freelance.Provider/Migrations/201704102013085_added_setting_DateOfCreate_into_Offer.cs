namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_setting_DateOfCreate_into_Offer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "DateOfCreate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offers", "DateOfCreate");
        }
    }
}
