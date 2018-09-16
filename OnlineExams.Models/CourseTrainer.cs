using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.Models
{
    public class CourseTrainer
    {
        public int Id { get; set; }
        public int CourseId{ get; set; }
        public virtual Course Course { get; set; }
        public int TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
