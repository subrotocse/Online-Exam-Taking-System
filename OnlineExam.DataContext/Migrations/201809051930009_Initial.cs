namespace OnlineExams.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CourseCode = c.String(),
                        CourseDuration = c.DateTime(nullable: false),
                        Credit = c.Double(nullable: false),
                        CourseOutLine = c.String(),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamType = c.String(),
                        ExamCode = c.String(),
                        Topic = c.String(),
                        FullMarks = c.Double(nullable: false),
                        Duration = c.DateTime(nullable: false),
                        CourseId = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId)
                .Index(t => t.CourseId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Org_Name = c.String(),
                        Org_Code = c.String(),
                        Address = c.String(),
                        ContactNo = c.String(),
                        About = c.String(),
                        Logo = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactNo = c.String(),
                        Email = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Image = c.Byte(nullable: false),
                        LeadTrainer = c.Boolean(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseTag",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        TagID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.TagID })
                .ForeignKey("dbo.Courses", t => t.CourseID)
                .ForeignKey("dbo.Tags", t => t.TagID)
                .Index(t => t.CourseID)
                .Index(t => t.TagID);
            
            CreateTable(
                "dbo.CourseTrainer",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        TrainerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.TrainerId })
                .ForeignKey("dbo.Courses", t => t.CourseID)
                .ForeignKey("dbo.Trainers", t => t.TrainerId)
                .Index(t => t.CourseID)
                .Index(t => t.TrainerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseTrainer", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.CourseTrainer", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.CourseTag", "TagID", "dbo.Tags");
            DropForeignKey("dbo.CourseTag", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Trainers", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Exams", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Courses", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseTrainer", new[] { "TrainerId" });
            DropIndex("dbo.CourseTrainer", new[] { "CourseID" });
            DropIndex("dbo.CourseTag", new[] { "TagID" });
            DropIndex("dbo.CourseTag", new[] { "CourseID" });
            DropIndex("dbo.Trainers", new[] { "OrganizationId" });
            DropIndex("dbo.Exams", new[] { "OrganizationId" });
            DropIndex("dbo.Exams", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "OrganizationId" });
            DropTable("dbo.CourseTrainer");
            DropTable("dbo.CourseTag");
            DropTable("dbo.Tags");
            DropTable("dbo.Trainers");
            DropTable("dbo.Organizations");
            DropTable("dbo.Exams");
            DropTable("dbo.Courses");
        }
    }
}
