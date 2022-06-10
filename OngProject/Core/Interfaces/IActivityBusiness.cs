using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using OngProject.Core.Models;

namespace OngProject.Core.Interfaces
{
    public interface IActivityBusiness
    {
        Task<List<Activity>> GetAll();
        Task<Activity> GetById(int id);
        Task<ActivityDto> Insert(ActivityInsertDto entity);
        Task<Response<ActivityDto>> Update(ActivityUpdateDto dto, int id);
        Task Delete(int id);
    }
}
