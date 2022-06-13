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

        public async Task<NewsDto> Insert(NewsInsertDto entity)
        {
            var news = entity.ToModel();
            news.Image = await Helper.ImageUploadHelper.UploadImageToS3(entity.Image);

            await _unitOfWork.NewsRepository.InsertAsync(news);
            await _unitOfWork.SaveAsync();

            return news.ToNewsDto();
        }

        public async Task<NewsDto> Update(int id, NewsInsertDto newsDto)
        {
            var news = await _unitOfWork.NewsRepository.GetByIdAsync(id);
            if (news == null) throw new KeyNotFoundException($"News with id = {id} is not existent");

            var category = await _unitOfWork.CategoriesRepository.GetByIdAsync(newsDto.CategoryId);
            if (category == null) throw new KeyNotFoundException($"Category with id = {newsDto.CategoryId} is not existent");

            await NewsMapper.UpdateNews(news, newsDto);

            await _unitOfWork.NewsRepository.UpdateAsync(news);
            await _unitOfWork.SaveAsync();

            return news.ToNewsDto();         


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