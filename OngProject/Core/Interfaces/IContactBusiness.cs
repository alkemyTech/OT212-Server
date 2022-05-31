using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IContactBusiness
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(int id);
        Task Insert(Contact entity);
        Task Update(Contact entity);
        Task Delete(int id);
    }
}
