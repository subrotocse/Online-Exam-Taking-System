using OnlineExam.Repository;
using OnlineExams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.BLL
{
    public class CourseTrainerManager : BaseManager<CourseTrainer>
    {
        public CourseTrainerManager() : base(new CourseTrainerRepository())
        {
        }
    }
}
