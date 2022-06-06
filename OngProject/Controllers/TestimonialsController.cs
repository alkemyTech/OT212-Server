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
        public IActionResult GetAll()
        {
            throw new NotImplementedException();
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

            if (response.Message == ResponseMessage.NotFound)
                return NotFound(response);

            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response.Data);
        }
    }
}
