using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class SlideBusiness : ISlideBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public SlideBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SlideDTO>> GetAll()
        {
            var slideList = await _unitOfWork.SlideRepository.GetAllAsync();

             return slideList.Select(x => SlideMapper.MapToSlideDTO(x)).ToList();
        }

        public async Task<SlideDetailsDto> GetById(int id)
        {
            var slide = await _unitOfWork.SlideRepository.GetByIdAsync(id);
            
            if (slide == null || slide.IsDeleted)
                return null;

            slide.Organization = await _unitOfWork.OrganizationRepository.GetByIdAsync(slide.OrganizationId);

            return slide.MapToSlideDetailsDto();
        }

        public Task Insert(Slide slide)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Slide slide)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
