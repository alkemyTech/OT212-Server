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

        public Task<Slide> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Response<SlideInsertDto>> Insert(SlideInsertDto slideDto)
        {
            var organization = await _unitOfWork.OrganizationRepository.GetByIdAsync(slideDto.OrganizationId);
            if (organization == null)
            {
                string[] errors = new string[]
                {
                    "The organization id does not exist!",
                    "Organization attribute was null!"
                };
                return new Response<SlideInsertDto>(slideDto, false, errors, ResponseMessage.ValidationErrors);
            }
            
            if(slideDto.Order is null)
            {
                slideDto.Order = (await _unitOfWork.SlideRepository.GetAllAsync()).Max(x => x.Order) + 1;
            }
            var slide = await SlideMapper.MapToSlideInsertDto(slideDto);

            await _unitOfWork.SlideRepository.InsertAsync(slide);

            await _unitOfWork.SaveAsync();

            return new Response<SlideInsertDto>(slideDto);
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
