using OnlineExam.Repository;
using OnlineExams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.BLL
{
   public class CourseManager
    {
        CourseRepository _courseRepository = new CourseRepository();
        public bool Add(Course entity)
        {
            return _courseRepository.Add(entity);
        }

       
        public bool Update(Course entity)
        {
            return _courseRepository.Update(entity);
        }


        public List<Course> GetAll()
        {
            return _courseRepository.GetAll();
        }


        public Course GetById(int? id)
        {
            return _courseRepository.GetById(id);
        }


        public bool Remove(Course entity)
        {
            return _courseRepository.Remove(entity);
        }
    }
}
