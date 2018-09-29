using OnlineExam.Repository;
using OnlineExams.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExams.BLL
{
    public class OrganizationManager:BaseManager<Organization>
    {
        //OrganizationRepository _organizationRepository = new OrganizationRepository();

        public OrganizationManager() : base(new OrganizationRepository())
        {
        }

        //public bool Add(Organization entity)
        //{
        //    return _organizationRepository.Add(entity);
        //}
        //public bool Remove(Organization entity)
        //{
        //    return _organizationRepository.Remove(entity);
        //}
        //public bool Update(Organization entity)
        //{
        //   return _organizationRepository.Update(entity);
        //}
        //public List<Organization> GetAll()
        //{
        //   return _organizationRepository.GetAll();
        //}
        //public Organization GetById(int? id)
        //{
        //   return _organizationRepository.GetById(id);
        //}
    }
}
