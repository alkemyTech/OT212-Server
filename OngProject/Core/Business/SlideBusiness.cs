using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
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

        public async Task<Response<SlideDetailsDto>> GetById(int id)
        {
            var slide = await _unitOfWork.SlideRepository.GetByIdAsync(id);

            if (slide == null || slide.IsDeleted) 
            {
                return new Response<SlideDetailsDto>(null, false, new string[] { "The id doesn't exist!" }, ResponseMessage.NotFound);
            }

            slide.Organization = await _unitOfWork.OrganizationRepository.GetByIdAsync(slide.OrganizationId);

            return new Response<SlideDetailsDto>(slide.MapToSlideDetailsDto());
        }

        public async Task<Response<SlideDetailsDto>> Insert(SlideInsertDto slideDto)
        {
            var organization = await _unitOfWork.OrganizationRepository.GetByIdAsync(slideDto.OrganizationId);
            if (organization == null)
            {
                string[] errors = new string[]
                {
                    "The organization id does not exist!",
                    "Organization attribute was null!"
                };
                return new Response<SlideDetailsDto>(null, false, errors, ResponseMessage.ValidationErrors);
            }
            
            if(slideDto.Order is null)
            {
                slideDto.Order = (await _unitOfWork.SlideRepository.GetAllAsync()).Max(x => x.Order) + 1;
            }
            var slide = await SlideMapper.MapToSlideInsertDto(slideDto);

            await _unitOfWork.SlideRepository.InsertAsync(slide);

            await _unitOfWork.SaveAsync();

            return new Response<SlideDetailsDto>(slideDto.MapToSlideDetailsDto(organization));
        }

        public Task Update(Slide slide)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<SlideDTO>> Delete(int id)
        {
            var slide = await _unitOfWork.SlideRepository.GetByIdAsync(id);
            if (slide == null)
                return new Response<SlideDTO>(null, false, new string[] {"The id doesn't exist!"}, ResponseMessage.NotFound);

            await _unitOfWork.SlideRepository.SoftDeleteAsync(slide);
            await _unitOfWork.SaveAsync();

            return new Response<SlideDTO>(slide.MapToSlideDTO(), true, null);

        }
    }
}
