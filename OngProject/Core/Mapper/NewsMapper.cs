using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public static class NewsMapper
    {
        public static NewsDto ToNewsDto(this News news)
        {
            NewsDto newsDto = new NewsDto();

            newsDto.Id = news.Id;
            newsDto.Name = news.Name;
            newsDto.Content = news.Content;
            newsDto.Image = news.Image;
            newsDto.CategoryId = news.CategoryId;
            newsDto.CategoryName = news.Category?.Name;

            return newsDto;
        }
        public static News ToModel(this NewsInsertDto newsInsertDto)
        {
            News news = new News();

            news.Name = newsInsertDto.Name;
            news.Content = newsInsertDto.Content;
            news.Image = newsInsertDto.Image?.FileName;
            news.CategoryId = newsInsertDto.CategoryId;

            return news;
        }

        public static NewsDto ToNewsDto(this NewsInsertDto newsInsertDto)
        {
            NewsDto newsDto = new NewsDto();

            newsDto.Name = newsInsertDto.Name;
            newsDto.Content = newsInsertDto.Content;
            newsDto.Image = newsInsertDto.Image?.FileName;
            newsDto.CategoryId = newsInsertDto.CategoryId;

            return newsDto;
        }
    }
}
