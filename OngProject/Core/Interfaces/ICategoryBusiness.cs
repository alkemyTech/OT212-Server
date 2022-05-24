using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;

namespace OngProject.Core.Business
{
    public interface ICategoryBusiness
    {
        public List<Category> GetAll();
        public Category GetById();
        public void Insert();
        public void Update();
        public void Delete();
    }
}
