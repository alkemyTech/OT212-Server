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
        public async Task<IActionResult> GetAll(int page, int pageSize = 10)
        {
            try
            {
                if (pageSize < 1 || page < 1)
                    return BadRequest(new Response<NewsDto>(null, false, new string[1]
                    {"Incorrect number of page or page size."}, ResponseMessage.ValidationErrors));

                var elementCount = await _newsBusiness.CountNews();
                var higherPageNumber = (int)Math.Ceiling(elementCount / (double)pageSize);

                if (page > higherPageNumber)
                    return BadRequest(new Response<NewsDto>(null, false, new string[1]
                        {$"Incorrect page. Maximum page number is {higherPageNumber}."},
                        ResponseMessage.ValidationErrors));

                var newsList = await _newsBusiness.GetAll(page, pageSize, $"{Request.Host}{Request.Path}");

                if (newsList.Items.Count == 0)
                    return NotFound(new Response<NewsDto>(null, false, new string[1]
                        {"News list is empty."}, ResponseMessage.NotFound));

                return Ok(new Response<PageList<NewsDto>>(newsList, true, null, ResponseMessage.Success));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<NewsDto>(null, false, new string[1]
                        {ex.Message},
                        ResponseMessage.UnexpectedErrors));
            }
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
