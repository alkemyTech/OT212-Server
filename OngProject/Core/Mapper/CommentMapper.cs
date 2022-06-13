using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public static class CommentMapper
    {
        public static CommentDto MapToCommentDto(this Comment entity) 
        { 
            return new CommentDto { Body = entity.Body };
        }

        public static Comment MapToComment(this CommentInsertDto entity)
        {
            return new Comment
            {
                Body = entity.Body,
                NewsId = entity.NewsId,
                UserId = entity.UserId
            };
        }
        public static void UpdateComment(Comment entity, CommentUpdateDto commentDto)
        {
            entity.Body = commentDto.Body;
        }
    }
}
