using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Entities;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private IRoleBusiness _roleBusiness;
        public RolesController(IRoleBusiness roleBusiness)
        {
            _roleBusiness = roleBusiness;
        }

        // GET: api/Roles
        [HttpGet]
        public IEnumerable<Role> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/Roles/5
        [HttpGet("{id}")]
        public Role Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/Roles
        [HttpPost]
        public ActionResult Post([FromBody] Role entity)
        {
            throw new NotImplementedException();
        }

        // PUT api/Roles/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Role entity)
        {
            throw new NotImplementedException();
        }

        // DELETE api/Roles/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
