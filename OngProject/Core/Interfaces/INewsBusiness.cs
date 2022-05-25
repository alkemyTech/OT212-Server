using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public interface INewsBusiness
    {
        Task<List<News>> GetAll();
        Task<News> GetById(int id);
        Task Insert(News entity);
        Task Update(News entity);
        Task Delete(int id);
    }
}