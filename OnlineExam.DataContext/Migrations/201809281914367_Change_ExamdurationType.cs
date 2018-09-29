namespace OnlineExam.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change_ExamdurationType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exams", "Duration", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exams", "Duration", c => c.DateTime(nullable: false));
        }
    }
}
