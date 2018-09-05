using OnlineExam.Repository;
using OnlineExams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.BLL
{
   public class ExamManager
    {
        ExamRepository _examRepository = new ExamRepository();
        public bool Add(Exam entity)
        {
            return _examRepository.Add(entity);
        }
        public bool Remove(Exam entity)
        {
            return _examRepository.Remove(entity);
        }
        public bool Update(Exam entity)
        {
            return _examRepository.Update(entity);
        }
        public List<Exam> GetAll()
        {
            return _examRepository.GetAll();
        }
        public Exam GetById(int? id)
        {
            return _examRepository.GetById(id);
        }
    }
}
