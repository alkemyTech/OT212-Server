using Microsoft.AspNetCore.Mvc;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Models;
using OngProject.Core.Mapper;
using Microsoft.AspNetCore.Authorization;

namespace OngProject.Controllers
{
    [Route("Slides")]
    [ApiController]
    public class SlideController : ControllerBase
    {
        private readonly ISlideBusiness _slideBusiness;

        public SlideController(ISlideBusiness slideBusiness)
        {
            _slideBusiness = slideBusiness;
        }

        #region Get

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _slideBusiness.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Post
        /* To Do:
         * Change Slide for SlideDto or SlideCreate (the name doesn't yet exist)
         * Create the implementation
         */
        [HttpPost]
        public async Task<ActionResult<Slide>> CreateSlide([FromForm] Slide slide)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        /* To Do:
         * Change Slide for SlideUpdateDto or SlideUpdate (the name doesn't yet exist)
         * Create the implementation
         */
        [HttpPut]
        public async Task<ActionResult<Slide>> UpdateSlide(int id, [FromForm] Slide slide)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<Response<SlideDTO>>> DeleteSlide(int id)
        {
            var result = await _slideBusiness.Delete(id);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        #endregion
    }
}
