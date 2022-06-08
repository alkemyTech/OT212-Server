using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IRoleBusiness
    {
        Task<Role> GetById(int id);

        Task<List<Role>> GetAll();

        Task Insert(Role entity);

        Task Update(Role entity);

        Task Delete(int id);
    }
}
