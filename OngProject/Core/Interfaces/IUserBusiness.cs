using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IUserBusiness
    {
        Task<User> GetById(int id);
        Task<List<User>> GetAll();
        Task Insert(User entity);
        Task Update(User entity);
        Task Delete(int id);

        Task<User> GetByEmail(string email);
    }
}