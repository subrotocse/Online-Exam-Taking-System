using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.Models.ViewModels
{
    public class CourseWithOrgAndTagVM
    {
        public Course Course { get; set; }
        public List<Organization> Organizations { get; set; }
        public virtual List<Tag> Tags { get; set; }

    }
}
