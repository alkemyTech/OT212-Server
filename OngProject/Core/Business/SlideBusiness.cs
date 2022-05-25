using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class SlideBusiness : ISlideBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public SlideBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Slide>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Slide> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert(Slide slide)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Slide slide)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
