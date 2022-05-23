using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using System;
using System.Collections.Generic;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
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
        public IEnumerable<Organization> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/Organizations/5
        [HttpGet("{id}")]
        public Organization Get(int id)
        {
            throw new NotImplementedException();
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
