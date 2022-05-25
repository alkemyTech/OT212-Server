using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class RoleBusiness : IRoleBusiness
    {
        private UnitOfWork _unitOfWork;
        public RoleBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Role>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Role> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert(Role entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Role entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
