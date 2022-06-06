using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class CommentBusiness : ICommentBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public CommentBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Comment>> GetAll()
        {
            var repository = _unitOfWork.CommentRepository;

            return await repository.GetAllAsync();
        }

        public Task<Comment> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task Insert(CommentInsertDto commentDto)
        {
            var userId = await _unitOfWork.UserRepository.GetByIdAsync(commentDto.UserId);
            var newsId = await _unitOfWork.NewsRepository.GetByIdAsync(commentDto.NewsId);

            if ((userId != null) && (newsId != null))
            {
                var comment = CommentMapper.MapToComment(commentDto);
                await _unitOfWork.CommentRepository.InsertAsync(comment);
                await _unitOfWork.SaveAsync();
            }
            else
                throw new Exception();
        }

        public Task Update(Comment entity)
        {
            throw new System.NotImplementedException();
        }
        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

    }
}
