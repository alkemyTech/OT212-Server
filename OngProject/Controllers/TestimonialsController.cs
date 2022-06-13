using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using System;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [ApiController]
    [Route("api/testimonials")]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialsBussines _testimonailsBussines;

        public TestimonialsController(ITestimonialsBussines testimonailsBussines)
        {
            _testimonailsBussines = testimonailsBussines;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(int page, int pageSize = 10)
        {
            try
            {
                if (pageSize < 1 || page < 1)
                    return BadRequest("Incorrect page or size number.");

                var elemntsCount = await _testimonailsBussines.CountElements();
                var higherPageNumber = (int)Math.Ceiling(elemntsCount / (double)pageSize);

                if (page > higherPageNumber)
                    return BadRequest($"Incorrect page. Max page number is {higherPageNumber}.");

                var tetismonialList = await _testimonailsBussines.GetAll(page, pageSize, $"{Request.Host}{Request.Path}");

                if (tetismonialList.Items.Count == 0)
                    return NotFound("Testimonial list is empty.");

                return Ok(tetismonialList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"TestimonialsController.GetAll: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<TestimonialDto>> Insert([FromForm] TestimonialCreationDto creationDto)
        {
            var response = await _testimonailsBussines.Insert(creationDto);

            if (!response.Succeeded)
                return BadRequest(response);
                
            return Ok(response.Data);
        }

        [HttpPut]
        public IActionResult Update()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<TestimonialDto>> Delete(int id)
        {
            var response = await _testimonailsBussines.Delete(id);

            if (response.Message == "Record not found")
                return NotFound(response);

            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response.Data);
        }
    }
}
