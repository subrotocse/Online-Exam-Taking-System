using OnlineExam.Repository;
using OnlineExams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.BLL
{
    public class ParticipantManager
    {
        ParticipantRepository _participantRepository = new ParticipantRepository();
        public bool Add(Participant entity)
        {
            return _participantRepository.Add(entity);
        }
        public bool Update(Participant entity)
        {
            return _participantRepository.Update(entity);
        }
        public List<Participant> GetAll()
        {
            return _participantRepository.GetAll();
        }
        public Participant GetById(int? id)
        {
            return _participantRepository.GetById(id);
        }
        public bool Remove(Participant entity)
        {
            return _participantRepository.Remove(entity);
        }
    }
}
