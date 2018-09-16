namespace OnlineExam.DataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchNo = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
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
                "dbo.CourseTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseTrainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        TrainerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Trainers", t => t.TrainerId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TrainerId);
            
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
                        LeadTrainer = c.Boolean(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId)
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
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.ExamSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.DateTime(nullable: false),
                        ExamId = c.Int(nullable: false),
                        BatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .ForeignKey("dbo.Exams", t => t.ExamId)
                .Index(t => t.ExamId)
                .Index(t => t.BatchId);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RegNo = c.String(),
                        ContactNo = c.String(),
                        Email = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Profession = c.String(),
                        HighestAcademic = c.String(),
                        ImagePath = c.String(),
                        BatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .Index(t => t.BatchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participants", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.ExamSchedules", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.ExamSchedules", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Trainers", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Courses", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.CourseTrainers", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.CourseTrainers", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.CourseTags", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Batches", "CourseId", "dbo.Courses");
            DropIndex("dbo.Participants", new[] { "BatchId" });
            DropIndex("dbo.ExamSchedules", new[] { "BatchId" });
            DropIndex("dbo.ExamSchedules", new[] { "ExamId" });
            DropIndex("dbo.Exams", new[] { "CourseId" });
            DropIndex("dbo.Trainers", new[] { "OrganizationId" });
            DropIndex("dbo.CourseTrainers", new[] { "TrainerId" });
            DropIndex("dbo.CourseTrainers", new[] { "CourseId" });
            DropIndex("dbo.CourseTags", new[] { "CourseId" });
            DropIndex("dbo.CourseTags", new[] { "TagId" });
            DropIndex("dbo.Courses", new[] { "OrganizationId" });
            DropIndex("dbo.Batches", new[] { "CourseId" });
            DropTable("dbo.Participants");
            DropTable("dbo.ExamSchedules");
            DropTable("dbo.Exams");
            DropTable("dbo.Organizations");
            DropTable("dbo.Trainers");
            DropTable("dbo.CourseTrainers");
            DropTable("dbo.Tags");
            DropTable("dbo.CourseTags");
            DropTable("dbo.Courses");
            DropTable("dbo.Batches");
        }
    }
}
