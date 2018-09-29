using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineExams.Models.View_Model
{
    public class TrainerCreateVM
    {
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public bool LeadTrainer { get; set; }
        public int OrganizationId { get; set; }
        public int CourseId { get; set; }

        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase Logo { get; set; }
        public List<SelectListItem> OrganizationLookUps { get; set; }
        public List<SelectListItem> CourseLookUps { get; set; }
    }
}
