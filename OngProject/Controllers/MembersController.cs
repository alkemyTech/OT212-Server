using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
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
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetAll()
        {
            var task = _memberBusiness.GetAll();

            var members = await task;

            if (members.Count == 0)
            {
                return NotFound("Members list is empty");
            }

            return Ok(members.Select(x => x.MapToMemberDto()));
        }

        [HttpGet("{id}")]
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
        [Authorize]
        public async Task<Response<MemberDto>> DeleteMemeber(int id)
        {
            try
            {
                var entity = await _memberBusiness.Delete(id);
                return new Response<MemberDto>(entity, true);
            }
            catch (KeyNotFoundException)
            {
                return new Response<MemberDto>(null, false, null, ResponseMessage.NotFound);
            }
            catch 
            {
                return new Response<MemberDto>(null, false, null, ResponseMessage.Error);
            }
        }

    }
}
