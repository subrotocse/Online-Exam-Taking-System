using OnlineExam.Repository;
using OnlineExams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.BLL
{
    public class TrainerManager:BaseManager<Trainer>
    {
        //TrainerRepository _trainerRepository = new TrainerRepository();

        public TrainerManager() : base(new TrainerRepository())
        {
        }

        //public bool Add(Trainer entity)
        //{
        //    return _trainerRepository.Add(entity);
        //}
        //public bool Remove(Trainer entity)
        //{
        //    return _trainerRepository.Remove(entity);
        //}
        //public bool Update(Trainer entity)
        //{
        //    return _trainerRepository.Update(entity);
        //}
        //public List<Trainer> GetAll()
        //{
        //    return _trainerRepository.GetAll();
        //}
        //public Trainer GetById(int? id)
        //{
        //    return _trainerRepository.GetById(id);
        //}
    }
}
