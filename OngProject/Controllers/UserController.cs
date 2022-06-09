using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            try
            {
                return Ok(_userBusiness.GetById(id));
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            try
            {
                return Ok(await _userBusiness.GetAll());
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }
        [HttpPost]
        public ActionResult Insert(User user)
        {
            try
            {
                _userBusiness.Insert(user);
                return Ok();
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<Response<UserDto>>> Update(int id, [FromForm] UserEditDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(new Response<UserDto>(user.ToUserDto(), 
                                        false, 
                                        (from item in ModelState.Values
                                        from error in item.Errors
                                        select error.ErrorMessage).ToArray(),
                                        ResponseMessage.ValidationErrors));
            try
            {
                var entity = await _userBusiness.GetById(id);
                if (entity == null)
                    return NotFound(new Response<UserDto>(entity, false, null, ResponseMessage.NotFound));

                var resp = await _userBusiness.Update(id, user);
                return Ok(new Response<UserDto>(resp,true));
            }
            catch (Exception)
            {
                return BadRequest(new Response<UserDto>(null, false, null, ResponseMessage.UnexpectedErrors));
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Usuario, Administrador")]
        public async Task<Response<User>> Delete(int id)
        {
            try
            {
                await _userBusiness.Delete(id);
                return new Response<User>(null, true);
            }
            catch
            {
                return new Response<User>(null, false, null, ResponseMessage.NotFound);
            }
        }
    }
}