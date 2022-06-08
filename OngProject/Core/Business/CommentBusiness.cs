
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
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

        public async Task<Comment> GetById(int id)
        {
            var comment = await _unitOfWork.CommentRepository.GetByIdAsync(id);
            return comment;
        }

        public async Task Insert(CommentInsertDto commentDto)
        {
            var newsId = await _unitOfWork.NewsRepository.GetByIdAsync(commentDto.NewsId);

            if (newsId != null)
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
        public async Task<CommentDto> Delete(int id)
        {
            var comment = await _unitOfWork.CommentRepository.GetByIdAsync(id);

            if ((comment != null) && (comment.IsDeleted == false))
            {
                var commentDto = CommentMapper.MapToCommentDto(comment);

                await _unitOfWork.CommentRepository.SoftDeleteAsync(comment);
                await _unitOfWork.SaveAsync();

                return commentDto;
            }
            else
                throw new KeyNotFoundException();
        }

    }
}
