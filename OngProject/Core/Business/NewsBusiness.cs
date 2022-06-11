using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<PageList<NewsDto>> GetAll(int page, int pageSize = 10, string url = "")
        {
            var query = new QueryProperty<News>(page, pageSize);
            var newsList = await _unitOfWork.NewsRepository.GetAllAsync(query);

            int totalItems = await CountElements();

            var list = newsList.Select(x => NewsMapper.ToNewsDto(x)).ToList();

            var pagelist = new PageList<NewsDto>(list, page, pageSize, totalItems, url);

            return pagelist;            
        }

        public async Task<int> CountElements()
            => await _unitOfWork.NewsRepository.Count();

        public async Task<NewsDto> GetById(int id)
        {
            var query = new QueryProperty<News>(1, 1);
            query.Where = x => x.Id == id;
            query.Includes.Add(x => x.Category);

            var entity = await _unitOfWork.NewsRepository.GetAsync(query);
            return entity?.ToNewsDto();
        }

        public async Task<NewsDto> Insert(NewsInsertDto entity)
        {
            var news = entity.ToModel();
            news.Image = await Helper.ImageUploadHelper.UploadImageToS3(entity.Image);

            await _unitOfWork.NewsRepository.InsertAsync(news);
            await _unitOfWork.SaveAsync();

            return news.ToNewsDto();
        }

        public Task Update(News entity)
        {
            throw new NotImplementedException();
        }
        public async Task Delete(int id)
        {
            var entity = await _unitOfWork.NewsRepository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException();

            await _unitOfWork.NewsRepository.SoftDeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}