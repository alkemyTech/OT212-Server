using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngProjectTests.Mocks
{
    public class OrganizationBusinessMock : IOrganizationBusiness
    {
        public Response<OrganizationDetailsDto> GetResponse { get; set; }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<OrganizationDetailsDto>> Get()
            => await Task.FromResult(GetResponse);

        public Task<List<Organization>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Organization> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Organization entity)
        {
            throw new NotImplementedException();
        }

        public Task<OrganizationDto> Update(int id, OrganizationUpdateDto organizationDto)
        {
            throw new NotImplementedException();
        }
    }
}
