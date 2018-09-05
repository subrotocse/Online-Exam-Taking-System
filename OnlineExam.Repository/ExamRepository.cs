using OnlineExams.DataContext;
using OnlineExams.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Repository
{
    public class ExamRepository
    {
        OnlineExamDbContext db = new OnlineExamDbContext();
        public bool Add(Exam entity)
        {
            db.Exams.Add(entity);
            return db.SaveChanges() > 0;
        }
        public bool Update(Exam entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Remove(Exam entity)
        {
            db.Exams.Remove(entity);
            return db.SaveChanges() > 0;
        }
        public List<Exam> GetAll()
        {
            return db.Exams.ToList();
        }
        public Exam GetById(int? id)
        {
            return db.Exams.FirstOrDefault(c => c.Id == id);
        }
    }
}
