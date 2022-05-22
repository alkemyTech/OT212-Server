using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;

namespace OngProject.Core.Business
{
    public class CategoriesBusiness: ICategoriesBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoriesBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Categories> GetAll()
        {
            throw new NotImplementedException();
        }

        public Categories GetById()
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
