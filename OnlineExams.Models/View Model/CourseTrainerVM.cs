using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.Models.View_Model
{
   public class CourseTrainerVM
    {
        public int TrainerId { get; set; }
        public int CourseId { get; set; }
        public bool IsLead { get; set; }
    }
}
