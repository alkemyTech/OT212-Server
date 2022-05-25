using System.Collections.Generic;
using System.Threading.Tasks;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;

namespace OngProject.Core.Business
{
    public class MemberBusiness : IMemberBusiness
    {
        private UnitOfWork _unitOfWork;
        public MemberBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Member>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Member> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert(Member entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Member entity)
        {
            throw new System.NotImplementedException();
        }
        public Task Delete(Member entity)
        {
            throw new System.NotImplementedException();
        }

    }
}
