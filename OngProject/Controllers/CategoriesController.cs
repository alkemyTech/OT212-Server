using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
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
                    return BadRequest("Category list is empty.");
                }

                return Ok(categoryDtoList);
            }
            catch(Exception ex)
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
        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }

    }
}
