using Microsoft.AspNetCore.Http;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ICommentBusiness
    {
        Task<List<Comment>> GetAll();

        Task<Comment> GetById(int id);

        Task Insert(CommentInsertDto commentDto);

        Task<CommentDto> Update(int id, CommentUpdateDto commentDto);

        Task <CommentDto> Delete(int id);
    }
}
