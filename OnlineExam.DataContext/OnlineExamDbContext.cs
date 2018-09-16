using OnlineExams.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.DataContext
{
    public class OnlineExamDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<CourseTag> CourseTags { get; set; }
        public DbSet<CourseTrainer> CourseTrainers { get; set; }
        public DbSet<ExamSchedule> ExamSchedules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //'FK_dbo.Participants_dbo.Organizations_OrganizationId' on table 'Trainers' may cause cycles or multiple cascade paths

            modelBuilder.Entity<Organization>()
        .HasMany<Trainer>(g => g.Trainers)
        .WithRequired(s => s.Organization)
        .WillCascadeOnDelete(false);

            //FK_dbo.ExamSchedules_dbo.Exams_ExamId' on table 'ExamSchedules' may cause cycles or multiple cascade paths. Specify ON DELETE NO ACTION or ON UPDATE NO ACTION,
            modelBuilder.Entity<Exam>()
         .HasMany<ExamSchedule>(g => g.ExamSchedules)
         .WithRequired(s => s.Exam)
         .WillCascadeOnDelete(false);
        }

    }
}


