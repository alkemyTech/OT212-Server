using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Controllers
{
    [Route("organization")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationBusiness _organizationBusiness;
        public OrganizationsController(IOrganizationBusiness organizationBusiness)
        {
            _organizationBusiness = organizationBusiness;
        }

        
        [HttpGet]
        public IEnumerable<Organization> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("public")]
        public async Task<ActionResult<OrganizationDetailsDto>> Get()
        {
            try
            {
                var organizationDetailsDto = await _organizationBusiness.Get();

                if (organizationDetailsDto == null)
                    return BadRequest(@"Can't find organization data.");

                return Ok(organizationDetailsDto);
            }
            catch (Exception e)
            {
                Console.WriteLine($@"OrganizationController.Get: {e.Message}");
                return BadRequest(@"Can't find organization data.");
            }
        }

        // POST api/Organizations
        [HttpPost]
        public ActionResult Post([FromBody] Organization value)
        {
            throw new NotImplementedException();
        }

        // PUT api/Organizations/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Organization entity)
        {
            throw new NotImplementedException();
        }

        // DELETE api/Organizations/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
