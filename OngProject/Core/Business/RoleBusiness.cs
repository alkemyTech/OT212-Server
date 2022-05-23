using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System.Collections.Generic;

namespace OngProject.Core.Business
{
    public class RoleBusiness : IRoleBusiness
    {
        private UnitOfWork _unitOfWork;
        public RoleBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Role GetById(int id)
        {
            return _unitOfWork.RoleRepository.GetById(id);
        }

        public List<Role> GetAll()
        {
            return _unitOfWork.RoleRepository.GetAll();
        }

        public void Insert(Role entity)
        {
            _unitOfWork.RoleRepository.Insert(entity);
            _unitOfWork.Save();
        }

        public void Update(Role entity)
        {
            _unitOfWork.RoleRepository.Update(entity);
            _unitOfWork.Save();
        }

        public void Delete(Role entity)
        {
            _unitOfWork.RoleRepository.Delete(entity);
            _unitOfWork.Save();
        }
    }
}
