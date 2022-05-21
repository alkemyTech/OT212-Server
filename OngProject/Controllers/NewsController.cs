using Microsoft.AspNetCore.Mvc;
using OngProject.Repositories;
using System;

namespace OngProject.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsBusiness _newsBusiness;

        public NewsController(NewsBusiness newsBusiness)
        {
            _newsBusiness = newsBusiness;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
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
