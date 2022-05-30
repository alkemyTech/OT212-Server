using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBusiness _authBusiness;
        
        public AuthController(IAuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<User>> Register(RegisterDto registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userDto = await _authBusiness.Register(registerUser);
                if (userDto == null)
                    return BadRequest("El usuario ya existe");

                return Ok(userDto);
            }
            catch (Exception)
            {
                return BadRequest("Ocurrió un error inesperado");
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto userDto)
        {
            try
            {
                return Ok(await _authBusiness.Login(userDto));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest("Algo salió mal.");
            }

        }
    }
}
