using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Entities;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/members")]
    public class MembersController : ControllerBase
    {
        private readonly IMemberBusiness _memberBusiness;

        public MembersController(IMemberBusiness memberBusiness)
        {
            _memberBusiness = memberBusiness;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Member>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Member> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Member entity)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Member entity)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
