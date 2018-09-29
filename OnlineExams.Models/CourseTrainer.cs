using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.Models
{
    public class CourseTrainer
    {
        [Key]
        [Column(Order =1)]
        public int CourseId{ get; set; }
        [Key]
        [Column(Order = 2)]
        public int TrainerId { get; set; }
        public virtual Course Course { get; set; }
        public bool IsLead { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
