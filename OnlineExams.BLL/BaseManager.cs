using OnlineExam.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.BLL
{
    public class BaseManager<T> where T:class
    {
        BaseRepository<T> _repository;
        public BaseManager(BaseRepository<T> repository)
        {
            _repository = repository;
        }
        public bool Add(T entity)
        {
            return _repository.Add(entity);
        }
        public bool Add(ICollection<T> entities)
        {
            return _repository.Add(entities);
        }
        public bool Update(T entity)
        {
            return _repository.Add(entity);
        }
        public bool Remove(T entity)
        {
            return _repository.Update(entity);
        }
        public List<T> GetAll()
        {
            return _repository.GetAll();
        }
        public T GetById(int? id)
        {
            return _repository.GetById(id);
        }
    }
}
