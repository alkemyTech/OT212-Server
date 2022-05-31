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
    }
}
