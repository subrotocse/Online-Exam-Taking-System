using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Web;

namespace OnlineExams.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Org_Name { get; set; }
        public string Org_Code { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string About { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase Logo { get; set; }
        public virtual List<Course> Courses { get; set; }
        public  virtual List<Trainer> Trainers { get; set; }
        public virtual List<Exam> Exams { get; set; }
    }
}
