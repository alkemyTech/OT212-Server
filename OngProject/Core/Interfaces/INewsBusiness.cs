using OngProject.Core.Models.DTOs;
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
        Task<NewsDto> GetById(int id);
        Task<NewsDto> Insert(NewsInsertDto entity);
        Task<NewsDto> Update(int id, NewsInsertDto entity);
        Task Delete(int id);
    }
}