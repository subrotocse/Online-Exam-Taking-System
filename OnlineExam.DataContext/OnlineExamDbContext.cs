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
       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Organization>()
          .HasMany<Exam>(g => g.Exams)
          .WithRequired(s => s.Organization)
          .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
             .HasMany(c => c.Trainers).WithMany(i => i.Courses)
             .Map(t => t.MapLeftKey("CourseID")
                 .MapRightKey("TrainerId")
                 .ToTable("CourseTrainer"));

            modelBuilder.Entity<Course>()
             .HasMany(c => c.Tags).WithMany(i => i.Courses)
             .Map(t => t.MapLeftKey("CourseID")
                 .MapRightKey("TagID")
                 .ToTable("CourseTag"));
        }

    }
}
    

