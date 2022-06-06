using Microsoft.AspNetCore.Mvc;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Models;

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
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<Response<SlideDetailsDto>>> GetById(int id)
        {
            var taskSlide = _slideBusiness.GetById(id);

            var slideResponse = await taskSlide;

            if(slideResponse.Succeeded)
            {
                return Ok(slideResponse);
                
            }
            else
            {
                return NotFound(slideResponse);
            }
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
        /* To Do:
         * Change Slide for SlideDeleteDto or SlideDelete (the name doesn't yet exist)
         * Create the implementation
         */
        [HttpDelete]
        public async Task<ActionResult<Slide>> DeleteSlide(int id, [FromForm] Slide slide)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
