namespace OnlineExam.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CourseTrainer : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CourseTrainers");
            AddPrimaryKey("dbo.CourseTrainers", new[] { "CourseId", "TrainerId" });
            DropColumn("dbo.CourseTrainers", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseTrainers", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.CourseTrainers");
            AddPrimaryKey("dbo.CourseTrainers", "Id");
        }
    }
}
