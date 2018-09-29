using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineExams.Models.View_Model
{
    public class CourseEditVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CourseCode { get; set; }
        public DateTime CourseDuration { get; set; }
        public double Credit { get; set; }
        public string CourseOutLine { get; set; }
        public int OrganizationId { get; set; }
        public ICollection<SelectListItem> OrganizationLookUps { get; set; }
        public ICollection<SelectListItem> TrainerLookUps { get; set; }
        public ICollection<SelectListItem> CourseLookUps { get; set; }
    }
}
