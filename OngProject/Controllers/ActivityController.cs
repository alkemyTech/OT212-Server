
using Microsoft.AspNetCore.Mvc;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using OngProject.Core.Business;
using Microsoft.AspNetCore.Http;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Models;
using System.Linq;
using OngProject.Core.Mapper;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private IActivityBusiness _activityBussines;

        public ActivityController(IActivityBusiness activityBussines)
        {
            _activityBussines = activityBussines;   
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
                var resp = await _activityBussines.Insert(entity);
                return new Response<ActivityDto>(resp, true);

            }
            catch (Exception)
            {
                return new Response<ActivityDto>(entity.ToActivityDto(), false, null, ResponseMessage.UnexpectedErrors);
            }
        }

        [HttpPut]
        public IActionResult Update()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }

    }
}
