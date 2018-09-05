using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExams.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseCode { get; set; }
        public DateTime CourseDuration { get; set; }
        public double Credit { get; set; }
        public string CourseOutLine { get; set; }
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual List<Trainer> Trainers { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual List<Exam> Exams { get; set; }
    }
}
