using OngProject.Core.Models;
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
        Task<int> CountNews();
        Task<PageList<NewsDto>> GetAll(int page, int pageSize, string url);
        Task<NewsDto> GetById(int id);
        Task<NewsDto> Insert(NewsInsertDto entity);
        Task<NewsDto> Update(int id, NewsInsertDto entity);
        Task Delete(int id);

        /// <summary>
        /// Search the list of comments associated with a news.
        /// </summary>
        /// <param name="newsId">The news id</param>
        /// <returns> If exist news return list of comments. If not found news retur null.</returns>
        Task<List<CommentDto>> GetComments(int newsId);
    }
}