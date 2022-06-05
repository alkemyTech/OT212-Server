using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ISlideBusiness
    {
        Task<List<SlideDTO>> GetAll();

        Task<SlideDetailsDto> GetById(int id);

        Task Insert(Slide slide);

        Task Update(Slide slide);

        Task Delete(int id);
    }
}
