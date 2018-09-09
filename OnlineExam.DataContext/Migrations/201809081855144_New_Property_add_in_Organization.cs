namespace OnlineExams.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_Property_add_in_Organization : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "ImagePath", c => c.String());
            DropColumn("dbo.Organizations", "Logo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organizations", "Logo", c => c.Byte(nullable: false));
            DropColumn("dbo.Organizations", "ImagePath");
        }
    }
}
