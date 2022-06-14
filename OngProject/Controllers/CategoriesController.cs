using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace OngProject.Controllers
{

    [SwaggerTag("Categories", "Web API para mantenimiento de Categorías")]
    [ApiController]
    [Route("api/categories")]
    [Authorize(Roles = "Administrador")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryBusiness _categoryBusiness;
        
        public CategoriesController(ICategoryBusiness categoryBusiness)
        {
            _categoryBusiness = categoryBusiness;
        }


        /// <summary>
        /// Obtiene una lista de objetos de tipo Categories, de forma paginada.
        /// </summary>
        /// <remarks>Si los requisitos son correctos, la lista de Categories se obtendrá correctamente (código 200). Si el objeto a obtener no existe, devuelve NotFound (código 404).
        /// Si hay una solicitud incorrecta, devuelve BadRequest (error 400). Si no está autorizado, devuelve Unauthorized (código 401)</remarks>
        /// /// <param name="page">Número de página a obtener.</param>
        /// /// <param name="pageSize">Cantidad de objetos en la página.</param>
        /// <response code="401">Unauthorized. No tienes permiso para ver esta información.</response>              
        /// <response code="200">OK. Objeto obtenido correctamente.</response>        
        /// <response code="400">BadRequest. Error de solicitud.</response>


        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] int page, [FromQuery] int pageSize = 10)
        {
            try
            {
                var categoryDtoList = await _categoryBusiness.GetAll(page,pageSize, $"{Request.Host}{Request.Path}");
                
                if(!categoryDtoList.Succeeded)
                    return BadRequest(categoryDtoList);

                return Ok(categoryDtoList);
            }
            catch (Exception)
            {
                return BadRequest(ResponseMessage.UnexpectedErrors);
            }
        }

        /// <summary>
        /// Obtiene un objeto de tipo Categories por su id.
        /// </summary>
        /// <remarks>Si los requisitos son correctos, el objeto Categories se obtendrá correctamente (código 200). Si el objeto a obtener no existe, devuelve NotFound (código 404).
        /// Si hay una solicitud incorrecta, devuelve BadRequest (error 400). Si no está autorizado, devuelve Unauthorized (error 401).</remarks>
        /// <param name="id">Id del objeto a actualizar.</param>
        /// <response code="401">Unauthorized. No tienes permiso para ver esta información.</response>              
        /// <response code="200">OK. Objeto obtenido correctamente.</response>        
        /// <response code="400">BadRequest. No se ha podido obtener el objeto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto.</response>

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var entity = await _categoryBusiness.GetById(id);
                if (entity == null)
                    return NotFound(new Response<CategoryDto>(entity, false, null, ResponseMessage.NotFound));
                return Ok(new Response<CategoryDto>(entity, true, null, ResponseMessage.Success));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<CategoryDto>(null, false, null, ex.Message));
            }
        }

        /// <summary>
        /// Inserta un objeto de tipo Categories
        /// </summary>
        /// <remarks>Si los requisitos son correctos, el objeto Categories se creará correctamente (código 201). Si el ModelState no es válido la respuesta será BadRequest (código 400).
        /// Si no está autorizado, devuelve Unauthorized (error 401).</remarks>
        /// <response code="401">Unauthorized. No autorizado para hacer este pedido.</response>              
        /// <response code="201">Created. Objeto creado correctamente.</response>        
        /// <response code="400">BadRequest. Error de solicitud errónea.</response>

        [HttpPost]
        public async Task<IActionResult> Insert([FromForm] CategoryInsertDto categoryDto)
        {
            try
            {
                var tryInsert = await _categoryBusiness.Insert(categoryDto);
                return Ok(new Response<CategoryDto>(tryInsert, true, null, ResponseMessage.Success));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<CategoryInsertDto>(categoryDto, false, null, ex.Message));
            }
        }

        /// <summary>
        /// Actualiza un objeto de tipo Categories
        /// </summary>
        /// <param name="id">Id del objeto a actualizar.</param>
        /// <remarks>Si los requisitos son correctos, el objeto Categories se actualizará correctamente (código 200). Si el objeto a actualizar o alguna otra entidad necesaria no existe, devuelve NotFound (código 404).
        /// Si hay una solicitud incorrecta, devuelve BadRequest (error 400). Si no está autorizado, devuelve Unauthorized (error 401).</remarks>
        /// <response code="401">Unauthorized. No tienes autorización.</response>              
        /// <response code="200">OK. Objeto actualizado correctamente.</response>        
        /// <response code="400">BadRequest. No se ha podido actualizar el objeto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto.</response>

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromForm] CategoryInsertDto categoryDto)
        {
            try
            {
                var entity = await _categoryBusiness.Update(id, categoryDto);
                return Ok(new Response<CategoryDto>(entity, true, null, ResponseMessage.Success));

            }
            catch (KeyNotFoundException)
            {
                return NotFound(new Response<CategoryDto>(null, false, null, ResponseMessage.NotFound));
            }
            catch
            {
                return BadRequest(new Response<CategoryDto>(null, false, null, ResponseMessage.Error));
            }

        }

        /// <summary>
        /// Borra un objeto de tipo Categories, haciendo un borrado lógico.
        /// </summary>
        /// <remarks>Si los requisitos son correctos, el objeto Categories se elimina correctamente (código 200). Si el objeto a eliminar no existe, devuelve NotFound (código 404).
        /// Si hay una solicitud incorrecta, devuelve BadRequest (error 400). Si no está autorizado, devuelve Unauthorized (error 401).</remarks>
        /// <param name="id">Id del objeto a eliminar.</param>
        /// <response code="401">Unauthorized. No tienes permiso para ver esta información.</response>              
        /// <response code="200">OK. Objeto eliminado correctamente.</response>        
        /// <response code="400">BadRequest. No se ha podido eliminar el objeto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto.</response>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var entity = await _categoryBusiness.GetById(id);
                if (entity == null)
                    return NotFound(new Response<CategoryDto>(entity, false, null, ResponseMessage.NotFound));
                await _categoryBusiness.Delete(id);
                return Ok(new Response<CategoryDto>(entity, true, null, ResponseMessage.Success));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<CategoryDto>(null, false, null, ex.Message));
            }
        }

    }
}
