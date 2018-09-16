using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.Models
{
    public class Batch
    {
        public int Id { get; set; }
        public string BatchNo { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual List<Participant> Participants { get; set; }
        public virtual List<ExamSchedule> ExamSchedules { get; set; }

    }
}
