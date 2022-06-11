using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Models;
using OngProject.Core.Mapper;

namespace OngProject.Controllers
{
    [SwaggerTag("Categories", "Web API para mantenimiento de Categorías")]
    [ApiController]
    [Route("api/activities")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityBusiness _activityBusiness;

        public ActivityController(IActivityBusiness activityBussines)
        {
            _activityBusiness = activityBussines;   
        }

        /// <summary>
        /// Inserta un objeto de tipo Activity
        /// </summary>
        /// <response code="401">Unauthorized. No tienes permiso para ver esta información.</response>              
        /// <response code="200">Created. Objeto creado correctamente.</response>        
        /// <response code="400">BadRequest. No se ha podido crear el objeto.</response>
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

        /// <summary>
        /// Actualiza un objeto de tipo Activity
        /// </summary>
        /// <param name="id">Id del objeto a actualizar.</param>
        /// <response code="401">Unauthorized. No tienes permiso para ver esta información.</response>              
        /// <response code="200">Updated. Objeto actualizado correctamente.</response>        
        /// <response code="400">BadRequest. No se ha podido actualizar el objeto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto.</response>
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

    }
}
