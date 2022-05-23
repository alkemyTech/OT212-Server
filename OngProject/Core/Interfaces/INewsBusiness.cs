using OngProject.Repositories;
using System;
using System.Collections.Generic;

namespace OngProject.Core.Business
{
    public interface INewsBusiness
    {
        public List<News> GetAll();
        public News GetById();
        public void Insert();
        public void Update();
        public void Delete();
    }
}