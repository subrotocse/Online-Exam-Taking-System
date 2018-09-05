using OnlineExam.Repository;
using OnlineExams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.BLL
{
   public class TagManager
    {
        TagRepository _tagRepository = new TagRepository();
        public bool Add(Tag entity)
        {
            return _tagRepository.Add(entity);
        }
        public bool Remove(Tag entity)
        {
            return _tagRepository.Remove(entity);
        }
        public bool Update(Tag entity)
        {
            return _tagRepository.Update(entity);
        }
        public List<Tag> GetAll()
        {
            return _tagRepository.GetAll();
        }
        public Tag GetById(int? id)
        {
            return _tagRepository.GetById(id);
        }
    }
}
