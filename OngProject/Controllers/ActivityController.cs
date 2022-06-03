
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
        public async Task<Response<ActivityInsertDto>> Insert([FromForm] ActivityInsertDto entity)
        {
            if (!ModelState.IsValid)
                return new Response<ActivityInsertDto>(entity, false, (from item in ModelState.Values
                                                                   from error in item.Errors
                                                                   select error.ErrorMessage).ToArray(),
                                                                        ResponseMessage.ValidationErrors);

            try
            {
                await _activityBussines.Insert(entity);
                return new Response<ActivityInsertDto>(entity, true);

            }
            catch (Exception)
            {
                return new Response<ActivityInsertDto>(entity, false, null, ResponseMessage.UnexpectedErrors);
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
