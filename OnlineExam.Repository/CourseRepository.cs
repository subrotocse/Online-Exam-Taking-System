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
    public class CourseRepository
    {
        OnlineExamDbContext db = new OnlineExamDbContext();
        public bool Add(Course entity)
        {
            db.Courses.Add(entity);
            return db.SaveChanges() > 0;
        }
        public bool Update(Course entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Remove(Course entity)
        {
            db.Courses.Remove(entity);
            return db.SaveChanges() > 0;
        }
        public List<Course> GetAll()
        {
            return db.Courses.Include(c=>c.Organization).ToList();
        }
        public Course GetById(int? id)
        {
            return db.Courses.FirstOrDefault(c => c.Id == id);
        }
    }
}
