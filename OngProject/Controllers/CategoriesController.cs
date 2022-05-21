using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Repositories;
using System;

namespace OngProject.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesBusiness _categoriesBusiness;

        public CategoriesController(ICategoriesBusiness categoriesBusiness)
        {
            _categoriesBusiness = categoriesBusiness;
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
