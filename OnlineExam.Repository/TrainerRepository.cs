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
    public class TrainerRepository
    {
        OnlineExamDbContext db = new OnlineExamDbContext();
        public bool Add(Trainer entity)
        {
            db.Trainers.Add(entity);
            return db.SaveChanges() > 0;
        }
        public bool Update(Trainer entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Remove(Trainer entity)
        {
            db.Trainers.Remove(entity);
            return db.SaveChanges() > 0;
        }
        public List<Trainer> GetAll()
        {
            return db.Trainers.ToList();
        }
        public Trainer GetById(int? id)
        {
            return db.Trainers.FirstOrDefault(c => c.Id == id);
        }
    }
}
