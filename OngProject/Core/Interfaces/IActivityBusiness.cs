using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IActivityBusiness
    {
        Task<List<Activity>> GetAll();
        Task<Activity> GetById(int id);
        Task Insert(ActivityInsertDto entity);
        Task Update(Activity entity);
        Task Delete(int id);
    }
}
