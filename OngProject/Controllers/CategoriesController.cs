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

        [HttpGet]
        public async Task<IActionResult> GetAll(int page,int pageSize = 10)
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
        /// Obtiene un objeto por su id
        /// </summary>
        /// <remarks>
        /// Si existe en la base de datos obtiene un objeto por su Id.
        /// </remarks>
        /// <param name="id">El id del objeto a buscar</param>
        /// <response code="400">BadRequest. Ocurrio un error inesperado al intentar acceder a los datos.</response>              
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>        
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
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
