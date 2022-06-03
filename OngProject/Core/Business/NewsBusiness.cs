using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
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

        public async Task<NewsDto> GetById(int id)
        {
            var query = new QueryProperty<News>(1, 1);
            query.Where = x => x.Id == id;
            query.Includes.Add(x => x.Category);

            var entity = await _unitOfWork.NewsRepository.GetAsync(query);
            return entity?.ToNewsDto();
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