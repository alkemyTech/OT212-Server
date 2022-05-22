using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.DataAccess;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("api/[controller]")]
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
        public ActionResult<List<User>> GetAll()
        {
            try
            {
                return Ok(_userBusiness.GetAll());
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
        [HttpDelete]
        public ActionResult Delete(User user)
        {
            try
            {
                _userBusiness.Delete(user);
                return Ok();
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }
        }
    }
}
