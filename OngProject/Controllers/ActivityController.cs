using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Models;
using OngProject.Core.Mapper;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/activities")]
    public class ActivityController : ControllerBase
    {
        private IActivityBusiness _activityBusiness;

        public ActivityController(IActivityBusiness activityBussines)
        {
            _activityBusiness = activityBussines;   
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<Response<ActivityDto>> Insert([FromForm] ActivityInsertDto entity)
        {
            if (!ModelState.IsValid)
                return new Response<ActivityDto>(entity.ToActivityDto(), false, (from item in ModelState.Values
                                                                   from error in item.Errors
                                                                   select error.ErrorMessage).ToArray(),
                                                                        ResponseMessage.ValidationErrors);

            try
            {
                var resp = await _activityBusiness.Insert(entity);
                return new Response<ActivityDto>(resp, true);

            }
            catch (Exception)
            {
                return new Response<ActivityDto>(entity.ToActivityDto(), false, null, ResponseMessage.UnexpectedErrors);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Response<ActivityDto>>> Update([FromForm] ActivityUpdateDto dto, int id)
        {
            var response = await _activityBusiness.Update(dto, id);

            if (response.Message == ResponseMessage.NotFound)
                return NotFound("Can't find the activity.");

            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }

    }
}
