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
using Swashbuckle.AspNetCore.Annotations;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/members")]
    [SwaggerTag("api/members", "Web API para mantenimiento de miembros.")]
    public class MembersController : ControllerBase
    {
        private readonly IMemberBusiness _memberBusiness;

        public MembersController(IMemberBusiness memberBusiness)
        {
            _memberBusiness = memberBusiness;
        }

        /// <summary>Obtiene la lista de miembros.</summary>
        /// <returns>Listado con los miembros de la organización.</returns>
        /// <remarks>
        /// Ejemplo de consulta:
        /// 
        ///     GET /api/members
        ///     
        /// </remarks>
        /// <response code="200">Listado obtenido correctamente.</response>
        /// <response code="400">Error de solicitud.</response>
        /// <response code="404">La lista no tiene miembros.</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetAll(int page, int pageSize = 10)
        {
            try
            {
                if (pageSize < 1 || page < 1)
                    return BadRequest(new Response<MemberDto>(null, false, new string[1]
                    {"Incorrect number of page or page size."}, ResponseMessage.ValidationErrors));

                var elementCount = await _memberBusiness.CountMembers();
                var higherPageNumber = (int)Math.Ceiling(elementCount / (double)pageSize);

                if (page > higherPageNumber)
                    return BadRequest(new Response<MemberDto>(null, false, new string[1]
                        {$"Incorrect page. Maximum page number is {higherPageNumber}."},
                        ResponseMessage.ValidationErrors));

                var memberList = await _memberBusiness.GetAll(page, pageSize, $"{Request.Host}{Request.Path}");

                if (memberList.Items.Count == 0)
                    return NotFound(new Response<MemberDto>(null, false, new string[1]
                        {"Member list is empty."}, ResponseMessage.NotFound));

                return Ok(new Response<PageList<MemberDto>>(memberList, true, null, ResponseMessage.Success));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<MemberDto>(null, false, new string[1]
                        {ex.Message},
                        ResponseMessage.UnexpectedErrors));
            }
        }

        /// <summary>Crear un nuevo miembro.</summary>
        /// <returns>Respuesta con el miembro creado.</returns>
        /// <remarks>
        /// Ejemplo de consulta:
        /// 
        ///     POST /api/members
        ///     {
        ///         "Name": "Nombre del Miembro",
        ///         "FacebookUrl": "facebook.com/miembro", 
        ///         "InstagramUrl": "instagram.com/miembro", 
        ///         "linkedinUrl": "linkedin.com/miembro", 
        ///         "Description": "Brebe descripción del nuevo miembro", 
        ///         "Image": binary[]
        ///     }
        /// </remarks>
        /// <response code="200">Retorna una respuesta satisfactoria con el miembro creado.</response>
        /// <response code="400">Retorna una respuesta con el error ocurrido al intentar la creación</response>
        [HttpPost]
        public async Task<Response<MemberDto>> CreateMember([FromForm] MemberInsertDto memberDto)
        {
            try
            {
                var entity =  await _memberBusiness.Insert(memberDto);
                return new Response<MemberDto>(entity,true);
            }
            catch
            {
                return new Response<MemberDto>(null, false, null, ResponseMessage.Error);
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Response<MemberDto>>> Update(int id, [FromForm] MemberUpdateDto entity)
        {
            var response = await _memberBusiness.Update(entity, id);

            if (response.Message == ResponseMessage.NotFound)
            {
                return NotFound(response);
            }
            if (response.Succeeded)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }

        }


        /// <summary>Eliminar un miembro.</summary>
        /// <returns>Respuesta con el miembro eliminado.</returns>
        /// <param name="id">Miembro a eliminar.</param>
        /// <remarks>
        /// Ejemplo de consulta:
        /// 
        ///     DELETE /api/members/8
        ///     
        /// </remarks>
        /// <response code="200">Retorna una respuesta satisfactoria con el miembro eliminado.</response>
        /// <response code="400">Retorna una respuesta con el error ocurrido al intentar la eliminación</response>
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
