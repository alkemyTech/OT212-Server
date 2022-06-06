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
        public IActionResult GetById()
        {
            throw new NotImplementedException();
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

        [HttpDelete]
        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }

    }
}
