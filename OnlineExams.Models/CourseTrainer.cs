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
<<<<<<< HEAD
        public bool IsLead { get; set; }
=======
      
>>>>>>> bec26b27843d4effc520e9a64f21d64bda4cf0ee
        public virtual Trainer Trainer { get; set; }
    }
}
