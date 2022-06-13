using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [SwaggerTag("News", "Web API para mantenimiento de Novedades")]
    [Route("[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly INewsBusiness _newsBusiness;

        public NewsController(INewsBusiness newsBusiness)
        {
            _newsBusiness = newsBusiness;
        }

        /// <summary>
        /// Obtiene una lista de objetos de tipo News, de forma paginada.
        /// </summary>
        /// <remarks>Si los requisitos son correctos, la lista de News se obtendrá correctamente (código 200). Si el objeto a obtener no existe, devuelve NotFound (código 404).
        /// Si hay una solicitud incorrecta, devuelve BadRequest (error 400). Si no está autorizado, devuelve Unauthorized (código 401)</remarks>
        /// /// <param name="page">Número de página a obtener.</param>
        /// /// <param name="pageSize">Cantidad de objetos en la página.</param>
        /// <response code="401">Unauthorized. No tienes permiso para ver esta información.</response>              
        /// <response code="200">OK. Objeto obtenido correctamente.</response>        
        /// <response code="400">BadRequest. Error de solicitud.</response>
        /// <response code="404">NotFound. La lista no tiene objetos.</response>
        [HttpGet]
        public async Task<IActionResult> GetAll(int page, int pageSize = 10)
        {
            try
            {
                if (pageSize < 1 || page < 1)
                    return BadRequest("Incorrect page or size number.");

                var elementsConnt = await _newsBusiness.CountElements();
                var higerPageNumber = (int)Math.Ceiling(elementsConnt / (double)pageSize);

                if (page > higerPageNumber)
                    return BadRequest($"Incorrect page. Max page number is {higerPageNumber}.");

                var NewsDtoList = await _newsBusiness.GetAll(page, pageSize, $"{Request.Host}{Request.Path}");

                if (NewsDtoList.Items.Count == 0)
                    return NotFound("Category list is empty.");

                return Ok(NewsDtoList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"NewsController.Get: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene un objeto de tipo News
        /// </summary>
        /// <remarks>Si los requisitos son correctos, el objeto News se obtendrá correctamente (código 200). Si el objeto a obtener no existe, devuelve NotFound (código 404).
        /// Si hay una solicitud incorrecta, devuelve BadRequest (error 400). Si no está autorizado, devuelve Unauthorized (error 401).</remarks>
        /// <param name="id">Id del objeto a actualizar.</param>
        /// <response code="401">Unauthorized. No tienes permiso para ver esta información.</response>              
        /// <response code="200">OK. Objeto obtenido correctamente.</response>        
        /// <response code="400">BadRequest. No se ha podido obtener el objeto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto.</response>
        [HttpGet("{id}")]
        public async Task<Response<NewsDto>> GetById(int id)
        {
            try
            {
                var entity = await _newsBusiness.GetById(id);
                if (entity == null)
                    return new Response<NewsDto>(entity, false, null, ResponseMessage.NotFound);

                return new Response<NewsDto>(entity, true, null, ResponseMessage.Success);
            }
            catch (Exception)
            {
                return new Response<NewsDto>(null, false, null, ResponseMessage.UnexpectedErrors);
            }
            
        }

        /// <summary>
        /// Inserta un objeto de tipo News
        /// </summary>
        /// <remarks>Si los requisitos son correctos, el objeto News se creará correctamente (código 201). Si el ModelState no es válido la respuesta será BadRequest (código 400).
        /// Si no está autorizado, devuelve Unauthorized (error 401).</remarks>
        /// <response code="401">Unauthorized. No autorizado para hacer este pedido.</response>              
        /// <response code="201">Created. Objeto creado correctamente.</response>        
        /// <response code="400">BadRequest. Error de solicitud errónea.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Response<NewsDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response<NewsDto>))]
        public async Task<Response<NewsDto>> Insert([FromForm] NewsInsertDto entity)
        {
            if (!ModelState.IsValid)
                return new Response<NewsDto>(entity.ToNewsDto(), false, (from item in ModelState.Values
                                                                   from error in item.Errors
                                                                   select error.ErrorMessage).ToArray(),
                                                                        ResponseMessage.ValidationErrors);

            try
            {
                var resp = await _newsBusiness.Insert(entity);
                return new Response<NewsDto>(resp, true);

            }
            catch (Exception)
            {
                return new Response<NewsDto>(entity.ToNewsDto(), false, null, ResponseMessage.UnexpectedErrors);
            }
        }
        /// <summary>
        /// Actualiza un objeto de tipo News
        /// </summary>
        /// <param name="id">Id del objeto a actualizar.</param>
        /// <remarks>Si los requisitos son correctos, el objeto News se actualizará correctamente (código 200). Si el objeto a actualizar o alguna otra entidad necesaria no existe, devuelve NotFound (código 404).
        /// Si hay una solicitud incorrecta, devuelve BadRequest (error 400). Si no está autorizado, devuelve Unauthorized (error 401).</remarks>
        /// <response code="401">Unauthorized. No tienes autorización.</response>              
        /// <response code="200">OK. Objeto actualizado correctamente.</response>        
        /// <response code="400">BadRequest. No se ha podido actualizar el objeto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto.</response>
        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] NewsInsertDto entity)
        {
            try
            {
                var resp = await _newsBusiness.Update(id, entity);
                return Ok(new Response<NewsDto>(resp, true, null, ResponseMessage.Success));

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new Response<NewsDto>(null, false, new string[1] { "An entity is missing" }, ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<NewsDto>(null, false, new string[1] { "Bad request error" }, ex.Message));
            }
        }

        /// <summary>
        /// Borra un objeto de tipo News, haciendo un borrado suave.
        /// </summary>
        /// <remarks>Si los requisitos son correctos, el objeto News se elimina correctamente (código 200). Si el objeto a eliminar no existe, devuelve NotFound (código 404).
        /// Si hay una solicitud incorrecta, devuelve BadRequest (error 400). Si no está autorizado, devuelve Unauthorized (error 401).</remarks>
        /// <param name="id">Id del objeto a eliminar.</param>
        /// <response code="401">Unauthorized. No tienes permiso para ver esta información.</response>              
        /// <response code="200">OK. Objeto eliminado correctamente.</response>        
        /// <response code="400">BadRequest. No se ha podido eliminar el objeto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto.</response>
        [HttpDelete("{id}")]
        public async Task<Response<NewsDto>> Delete(int id)
        {
            try
            {
                var entity = await _newsBusiness.GetById(id);
                if (entity == null)
                    return new Response<NewsDto>(entity, false, null, ResponseMessage.NotFound);

                await _newsBusiness.Delete(id);
                return new Response<NewsDto>(entity, true, null, ResponseMessage.Success);
            }
            catch (Exception)
            {
                return new Response<NewsDto>(null, false, null, ResponseMessage.UnexpectedErrors);
            }
        }

        [HttpGet("{id}/[Action]")]
        public async Task<Response<List<CommentDto>>> Comments(int id)
        {
            try
            {
                var entity = await _newsBusiness.GetComments(id);
                if (entity == null)
                    return new Response<List<CommentDto>>(entity, false, null, ResponseMessage.NotFound);
                return new Response<List<CommentDto>>(entity, true, null, ResponseMessage.Success);
            }
            catch (Exception ex)
            {
                return new Response<List<CommentDto>>(null, false, null, ResponseMessage.UnexpectedErrors);
            }
        }
    }
}
