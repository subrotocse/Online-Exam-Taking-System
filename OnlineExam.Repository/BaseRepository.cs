using OnlineExams.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExam.Repository
{
    public abstract class BaseRepository<T> where T:class
    {
        protected OnlineExamDbContext db = new OnlineExamDbContext();

        public bool Add(T entity)
        {
            db.Set<T>().Add(entity);
            return db.SaveChanges() > 0;
        }
        public bool Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Remove(T entity)
        {
            db.Set<T>().Remove(entity);
            return db.SaveChanges() > 0;
        }

        public List<T> GetAll()
        {
            // return db.Courses.Include(c => c.Organization).ToList();
            return db.Set<T>().ToList();

        }
        public T GetById(int? id)
        {
            // return db.Courses.FirstOrDefault(c => c.Id == id);
            return db.Set<T>().Find(id);

        }






    }
}
