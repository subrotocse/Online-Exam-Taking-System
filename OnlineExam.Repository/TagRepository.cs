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
    public class TagRepository
    {
        OnlineExamDbContext db = new OnlineExamDbContext();
        public bool Add(Tag entity)
        {
            db.Tags.Add(entity);
            return db.SaveChanges() > 0;
        }
        public bool Update(Tag entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Remove(Tag entity)
        {
            db.Tags.Remove(entity);
            return db.SaveChanges() > 0;
        }
        public List<Tag> GetAll()
        {
            return db.Tags.ToList();
        }
        public Tag GetById(int? id)
        {
            return db.Tags.FirstOrDefault(c => c.Id == id);
        }
    }
}
