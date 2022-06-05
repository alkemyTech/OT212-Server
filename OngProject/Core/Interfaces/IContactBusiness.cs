using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IContactBusiness
    {
        Task<List<ContactDto>> GetAll();
        Task<Contact> GetById(int id);
        Task Insert(ContactDto entity);
        Task Update(Contact entity);
        Task Delete(int id);
    }
}
