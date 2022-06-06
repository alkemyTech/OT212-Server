using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class OrganizationBusiness : IOrganizationBusiness
    {
        private readonly UnitOfWork _unitOfWork;
        public OrganizationBusiness(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<Organization>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<OrganizationDetailsDto> Get()
        {
            var organizationList = await _unitOfWork.OrganizationRepository.GetAllAsync();
            
            var organization = organizationList.FirstOrDefault();

            var slideList = (await _unitOfWork.SlideRepository.GetAllAsync())
                            .Where(x => x.OrganizationId == organization.Id)
                            .OrderBy(x => x.Order)
                            .Select(x => x.MapToSlideDTO());


            return organization.MapToOrganizationDetailsDto(slideList);
        }

        public Task<Organization> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Organization entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Organization entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
