using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Controllers
{
    [Route("organization")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private IOrganizationBusiness _organizationBusiness;
        public OrganizationsController(IOrganizationBusiness organizationBusiness)
        {
            _organizationBusiness = organizationBusiness;
        }

        // GET: api/Organizations
        [HttpGet]
        public IEnumerable<Organization> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("public")]
        public async Task<ActionResult<Response<OrganizationDetailsDto>>> Get()
        {
            var responseOrganizationDetailsDto = await _organizationBusiness.Get();

            if (responseOrganizationDetailsDto.Succeeded)
            {
                return Ok(responseOrganizationDetailsDto);
            }
            else
            {
                return BadRequest(responseOrganizationDetailsDto);
            }
        }

        // POST api/Organizations
        [HttpPost]
        public ActionResult Post([FromBody] Organization value)
        {
            throw new NotImplementedException();
        }

        // PUT api/Organizations/5
        [HttpPut("public/{id}")]
        public async Task<ActionResult> Update(int id, [FromForm] OrganizationUpdateDto organizationDto)
        {
            try
            {
                var entity = await _organizationBusiness.Update(id, organizationDto);
                return Ok(new Response<OrganizationDto>(entity, true, null, ResponseMessage.Success));
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new Response<OrganizationDto>(null, false, null, ResponseMessage.NotFound));
            }
            catch
            {
                return BadRequest(new Response<OrganizationDto>(null, false, null, ResponseMessage.Error));
            }
        }

        // DELETE api/Organizations/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
