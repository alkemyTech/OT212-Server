using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public static class NewsMapper
    {
        public static NewsDto ToNewsDto(this News news)
        {
            NewsDto newsDto = new NewsDto();

            newsDto.Name = news.Name;
            newsDto.Content = news.Content;
            newsDto.Image = news.Image;
            newsDto.CategoryId = news.CategoryId;
            newsDto.CategoryName = news.Category?.Name;

            return newsDto;

        }
    }
}
