namespace OnlineExam.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIslead_property : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseTrainers", "IsLead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseTrainers", "IsLead");
        }
    }
}
