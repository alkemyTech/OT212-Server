using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ICommentBusiness
    {
        Task<List<Comment>> GetAll();

        Task<Comment> GetById(int id);

        Task Insert(Comment entity);

        Task Update(Comment entity);

        Task Delete(int id);
    }
}
