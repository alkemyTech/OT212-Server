using OngProject.Core.Interfaces;
using OngProject.Entities;
using OngProject.Repositories;
using System.Collections.Generic;

namespace OngProject.Core.Business
{
    public class ActivityBussines : IActivityBussines
    {
        private UnitOfWork _unitOfWork;

        public ActivityBussines(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;   
        }

        public List<Activity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Activity GetById()
        {
            throw new System.NotImplementedException();
        }

        public void Insert()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }
    }
}
