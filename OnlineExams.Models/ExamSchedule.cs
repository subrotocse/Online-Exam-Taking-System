using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.Models
{
    public class ExamSchedule
    {
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public int BatchId { get; set; }
        public virtual Batch Batch { get; set; }
    }
}
