namespace Freelance.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changed_attributes_for_tables_User_and_Category_added_Table_Profile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.String(),
                        DescriptionProfile = c.String(nullable: false),
                        TimeFrom = c.Time(nullable: false, precision: 7),
                        TimeTo = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Id)
                .Index(t => t.Id);
            
            AlterColumn("dbo.Categories", "NameCategory", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "DescriptionCategory", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "Id", "dbo.Categories");
            DropIndex("dbo.Profiles", new[] { "Id" });
            AlterColumn("dbo.Categories", "DescriptionCategory", c => c.String());
            AlterColumn("dbo.Categories", "NameCategory", c => c.String());
            DropTable("dbo.Profiles");
        }
    }
}
