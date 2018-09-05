using OnlineExams.DataContext;
using OnlineExams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OnlineExam.Repository
{
    public class OrganizationRepository
    {
        OnlineExamDbContext db = new OnlineExamDbContext();
        public bool Add(Organization entity)
        {
            db.Organizations.Add(entity);
            return db.SaveChanges()>0;
        }
        public bool Update(Organization entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        public bool Remove(Organization entity)
        {
            db.Organizations.Remove(entity);
            return db.SaveChanges()>0;
        }
        public List<Organization> GetAll()
        {
            return db.Organizations.ToList();
        }
        public Organization GetById(int? id)
        {
           return db.Organizations.FirstOrDefault(c=>c.Id==id);
        }
    }
}
