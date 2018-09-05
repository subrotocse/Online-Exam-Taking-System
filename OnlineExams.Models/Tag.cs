using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExams.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Course> Courses { get; set; }
    }
}
