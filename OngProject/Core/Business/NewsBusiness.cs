using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class NewsBusiness : INewsBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public NewsBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<News>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<News> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(News entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(News entity)
        {
            throw new NotImplementedException();
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}