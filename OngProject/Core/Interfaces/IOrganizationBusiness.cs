using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IOrganizationBusiness
    {
        Task<List<Organization>> GetAll();

        Task<Response<OrganizationDetailsDto>> Get();

        Task<Organization> GetById(int id);

        Task Insert(Organization entity);

        Task<OrganizationDto> Update(int id, OrganizationUpdateDto organizationDto);

        Task Delete(int id);
    }
}
