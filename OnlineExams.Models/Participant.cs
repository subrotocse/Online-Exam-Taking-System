using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineExams.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RegNo { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Profession { get; set; }
        public string HighestAcademic { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase Image { get; set; }
        public int BatchId { get; set; }
        public virtual Batch Batch { get; set; }
    }
}
