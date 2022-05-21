using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class OrganizationBusiness
    {
        private UnitOfWork _unitOfWork;
        public OrganizationBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Organization GetById(int id)
        {
            return _unitOfWork.OrganizationRepository.GetById(id);
        }

        public List<Organization> GetAll()
        {
            return _unitOfWork.OrganizationRepository.GetAll();
        }

        public void Insert(Organization entity)
        {
            _unitOfWork.OrganizationRepository.Insert(entity);
            _unitOfWork.Save();
        }

        public void Update(Organization entity)
        {
            _unitOfWork.OrganizationRepository.Update(entity);
            _unitOfWork.Save();
        }

        public void Delete(Organization entity)
        {
            _unitOfWork.OrganizationRepository.SoftDelete(entity);
            _unitOfWork.Save();
        }
    }
}
