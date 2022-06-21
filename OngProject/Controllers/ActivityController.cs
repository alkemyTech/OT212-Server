using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Core.Models;
using OngProject.Core.Mapper;
using Microsoft.AspNetCore.Http;

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
        /// <remarks>Si el objeto a insertar en la base de datos cumple con los requisitos, será creado correctamente (código 201), caso contrario, si el ModelState es inválido mandará un BadRequest (código 400).</remarks>
        /// <response code="401">Unauthorized. No tienes permiso para ver esta información.</response>              
        /// <response code="201">Created. Objeto creado correctamente.</response>        
        /// <response code="400">BadRequest. No se ha podido crear el objeto.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Response<ActivityDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response<ActivityDto>))]
        public async Task<ActionResult<Response<ActivityDto>>> Insert([FromForm] ActivityInsertDto entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Response<ActivityDto>(entity.ToActivityDto(), false, (from item in ModelState.Values
                                                                                            from error in item.Errors
                                                                                            select error.ErrorMessage).ToArray(),
                                                                                            ResponseMessage.ValidationErrors));
            
            try
            {
                var resp = await _activityBusiness.Insert(entity);
                return Ok(new Response<ActivityDto>(resp, true));

            }
            catch (Exception)
            {
                return BadRequest(new Response<ActivityDto>(entity.ToActivityDto(), false, null, ResponseMessage.UnexpectedErrors));
            }
        }

        /// <summary>
        /// Actualiza un objeto de tipo Activity
        /// </summary>
        /// <remarks>Siempre y cuando el objeto exista en la base de datos, se podrá actualizar, de lo contrario no se podrá actualizar y mandará un NotFound (código 404) porque no se encontró el objeto.</remarks>
        /// <param name="dto">Objeto a actualizar</param>
        /// <param name="id">Id del objeto a actualizar.</param>
        /// <response code="401">Unauthorized. No tienes permiso para ver esta información.</response>              
        /// <response code="200">Updated. Objeto actualizado correctamente.</response>        
        /// <response code="400">BadRequest. No se ha podido actualizar el objeto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto.</response>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<ActivityDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response<ActivityDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
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
