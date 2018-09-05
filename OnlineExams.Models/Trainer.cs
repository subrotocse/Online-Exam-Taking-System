using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExams.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public byte Image { get; set; }
        public bool LeadTrainer { get; set; }
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual List<Course> Courses { get; set; } 
    }
}
