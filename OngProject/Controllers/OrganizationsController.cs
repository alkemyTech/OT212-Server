using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
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
        public async Task<ActionResult<Organization>> Get()
        {
            try
            {
                var organizationDto = await _organizationBusiness.Get();

                if (organizationDto == null)
                    return BadRequest(@"Can't find organization data.");

                return Ok(organizationDto);
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
