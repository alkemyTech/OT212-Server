using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using System;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
