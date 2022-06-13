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

        Task<Response<SlideDetailsDto>> GetById(int id);

        Task<Response<SlideDetailsDto>> Insert(SlideInsertDto slideDto);

        Task<Response<SlideUpdateDto>> Update(int id, SlideInsertDto slideDto);

        Task<Response<SlideDTO>> Delete(int id);
    }
}
