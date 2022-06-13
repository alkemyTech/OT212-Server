using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Business;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("[controller]")]
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
        public async Task<Response<NewsDto>> Insert([FromForm] NewsInsertDto entity)
        {
            if (!ModelState.IsValid)
                return new Response<NewsDto>(entity.ToNewsDto(), false, (from item in ModelState.Values
                                                                   from error in item.Errors
                                                                   select error.ErrorMessage).ToArray(),
                                                                        ResponseMessage.ValidationErrors);

            try
            {
                var resp = await _newsBusiness.Insert(entity);
                return new Response<NewsDto>(resp, true);

            }
            catch (Exception)
            {
                return new Response<NewsDto>(entity.ToNewsDto(), false, null, ResponseMessage.UnexpectedErrors);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, [FromForm] NewsInsertDto entity)
        {
            try
            {
                var resp = await _newsBusiness.Update(id, entity);
                return Ok(new Response<NewsDto>(resp, true, null, ResponseMessage.Success));

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new Response<NewsDto>(null, false, new string[1] { "An entity is missing" }, ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<NewsDto>(null, false, new string[1] { "Bad request error" }, ex.Message));
            }
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
