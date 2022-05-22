using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;

namespace OngProject.Core.Business
{
    public interface ICategoriesBusiness
    {
        public List<Categories> GetAll();
        public Categories GetById();
        public void Insert();
        public void Update();
        public void Delete();
    }
}
