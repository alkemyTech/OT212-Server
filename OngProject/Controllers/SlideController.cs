using Microsoft.AspNetCore.Mvc;
using OngProject.Entities;
using System.Threading.Tasks;
using System;
using OngProject.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Models;

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

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<Response<SlideDetailsDto>>> Insert([FromForm] SlideInsertDto slideDto)
        {
            var result = await _slideBusiness.Insert(slideDto);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
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
