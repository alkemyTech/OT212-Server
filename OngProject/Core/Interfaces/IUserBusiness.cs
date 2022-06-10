using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IUserBusiness
    {
        Task<UserDto> GetById(int id);
        Task<List<UserDto>> GetAll();
        Task Insert(User entity);
        Task<UserDto> Update(int id, UserEditDto entity);
        Task Delete(int id);

        Task<User> GetByEmail(string email);
    }
}