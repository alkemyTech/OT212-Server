using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ISlideBusiness
    {
        Task<List<SlideDTO>> GetAll();

        Task<Slide> GetById(int id);

        Task Insert(Slide slide);

        Task Update(Slide slide);

        Task<Response<SlideDTO>> Delete(int id);
    }
}
