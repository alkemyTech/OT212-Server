using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/categories")]
    //[Authorize(Roles = "Administrador")]
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
                if (pageSize < 1 || page < 1)
                    return BadRequest("Incorrect page or size number.");

                var elemntsCount = await _categoryBusiness.CountElements();
                var higherPageNumber = (int)Math.Ceiling(elemntsCount / (double)pageSize);

                if (page > higherPageNumber)
                    return BadRequest($"Incorrect page. Max page number is {higherPageNumber}.");

                var categoryDtoList = await _categoryBusiness.GetAll(page,pageSize, $"{Request.Host}{Request.Path}");

                if (categoryDtoList.Items.Count == 0)
                    return NotFound("Category list is empty.");

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

        [HttpPut]
        public IActionResult Update()
        {
            throw new NotImplementedException();
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
