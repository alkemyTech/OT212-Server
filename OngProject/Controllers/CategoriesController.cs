using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Repositories;
using System;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var categoryDtoList = await _categoryBusiness.GetAll();

                if (categoryDtoList.Count == 0)
                {
                    return NotFound("Category list is empty.");
                }

                return Ok(categoryDtoList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"CategoriesController.Get: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

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
            catch(Exception ex)
            {
                return BadRequest(new Response<CategoryDto>(null, false, null, ex.Message));
            }
        }

        [HttpPost]
        public IActionResult Insert()
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult Update()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
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
