using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private OrganizationBusiness _organizationBusiness;
        public OrganizationsController(OrganizationBusiness organizationBusiness)
        {
            _organizationBusiness = organizationBusiness;
        }

        // GET: api/<OrganizationsController>
        [HttpGet]
        public IEnumerable<Organization> Get()
        {
            return _organizationBusiness.GetAll();
        }

        // GET api/<OrganizationsController>/5
        [HttpGet("{id}")]
        public Organization Get(int id)
        {
            return _organizationBusiness.GetById(id);
        }

        // POST api/<OrganizationsController>
        [HttpPost]
        public ActionResult Post([FromBody] Organization value)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            _organizationBusiness.Insert(value);

            return Ok(value);
        }

        // PUT api/<OrganizationsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Organization entity)
        {
            if (!ModelState.IsValid || entity.Id != id) { return BadRequest(); }

            _organizationBusiness.Update(entity);

            return NoContent();
        }

        // DELETE api/<OrganizationsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entity = _organizationBusiness.GetById(id);
            _organizationBusiness.Delete(entity);

            return NoContent();
        }
    }
}
