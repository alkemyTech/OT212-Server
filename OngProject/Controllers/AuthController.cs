using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBusiness _authBusiness;
        private readonly IUserBusiness _userBusiness;

        public AuthController(IAuthBusiness authBusiness, IUserBusiness userBusiness)
        {
            _authBusiness = authBusiness;
            _userBusiness = userBusiness;
        }

        [HttpPost]
        [Authorize(Roles = "Administrador, Usuario")]
        [Route("me")]
        public async Task<ActionResult<Response<UserDto>>> GetUserData()
        {
            try
            {
                string userEmail = User.FindFirst(ClaimTypes.Email)?.Value.ToString();
                var userDto = UserMapper.ToUserDto(await _userBusiness.GetByEmail(userEmail));
                return Ok(new Response<UserDto>(userDto, true, null, ResponseMessage.Success));
            }
            catch (Exception ex)
            {
                return BadRequest(new Response<UserDto>(null, false, null, ex.Message));
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<User>> Register([FromForm] RegisterDto registerUser)
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
