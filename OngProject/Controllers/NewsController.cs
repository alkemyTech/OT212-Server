using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsBusiness _newsBusiness;

        public NewsController(INewsBusiness newsBusiness)
        {
            _newsBusiness = newsBusiness;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<Response<NewsDto>> GetById(int id)
        {
            try
            {
                var entity = await _newsBusiness.GetById(id);
                if (entity == null)
                    return new Response<NewsDto>(entity, false, null, ResponseMessage.NotFound);

                return new Response<NewsDto>(entity, true, null, ResponseMessage.Success);
            }
            catch (Exception)
            {
                return new Response<NewsDto>(null, false, null, ResponseMessage.UnexpectedErrors);
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

        [HttpDelete("{id}")]
        public async Task<Response<NewsDto>> Delete(int id)
        {
            try
            {
                var entity = await _newsBusiness.GetById(id);
                if (entity == null)
                    return new Response<NewsDto>(entity, false, null, ResponseMessage.NotFound);

                await _newsBusiness.Delete(id);
                return new Response<NewsDto>(entity, true, null, ResponseMessage.Success);
            }
            catch (Exception)
            {
                return new Response<NewsDto>(null, false, null, ResponseMessage.UnexpectedErrors);
            }
        }
    }
}
