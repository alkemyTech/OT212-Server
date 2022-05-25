using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class ActivityBusiness : IActivityBusiness
    {
        private UnitOfWork _unitOfWork;

        public ActivityBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }

        public Task<List<Activity>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Activity> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Insert(Activity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Activity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
