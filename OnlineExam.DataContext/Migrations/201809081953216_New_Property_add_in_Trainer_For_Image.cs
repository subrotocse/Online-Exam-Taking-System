namespace OnlineExams.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class New_Property_add_in_Trainer_For_Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "ImagePath", c => c.String());
            DropColumn("dbo.Trainers", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "Image", c => c.Byte(nullable: false));
            DropColumn("dbo.Trainers", "ImagePath");
        }
    }
}
