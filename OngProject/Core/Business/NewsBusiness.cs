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

        public async Task<List<CommentDto>> GetComments(int newsId)
        {
            var query = new QueryProperty<Comment>();
            query.Where = x => x.NewsId == newsId;
            query.Includes.Add(x => x.News);
            query.Includes.Add(x => x.User);

            var resp = await _unitOfWork.CommentRepository.GetAllAsync(query);

            return resp.Select(x => x.MapToCommentDto()).ToList();
        }
    }
}