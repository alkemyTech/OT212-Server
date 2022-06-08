﻿using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
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

        public async Task<Response<OrganizationDetailsDto>> Get()
        {
            var organizationList = await _unitOfWork.OrganizationRepository.GetAllAsync();

            var organization = organizationList.FirstOrDefault();

            if(organization == null || organization.IsDeleted)
            {
                string[] errors = new string[]
                {
                    "The organization id does not exist!",
                    "Organization attribute was null!"
                };
                return new Response<OrganizationDetailsDto>(null, false, errors, ResponseMessage.NotFound);
            }

            var slideList = (await _unitOfWork.SlideRepository.GetAllAsync())
                            .Where(x => x.OrganizationId == organization.Id)
                            .OrderBy(x => x.Order)
                            .Select(x => x.MapToSlideDTO());


            return new Response<OrganizationDetailsDto>(organization.MapToOrganizationDetailsDto(slideList));
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
