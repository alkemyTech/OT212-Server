using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
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
        [HttpPut]
        public ActionResult Update(User user)
        {
            try
            {
                _userBusiness.Update(user);
                return Ok();
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }
        [HttpDelete("{id}")]
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