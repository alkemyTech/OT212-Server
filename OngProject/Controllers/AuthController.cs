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

        /// <summary>
        /// Devuelve la información de la cuenta del usuario actual.
        /// </summary>
        /// <remarks>Si hay una sesión iniciada devolvera todos los datos del usuario actual código(200). Si no hay ningúna sesión de usuario o el token no corresponde a un usuario registrado devolvera un Unauthorized código(401).</remarks>
        /// <response code="200">Ok. Información del usuario actual</response>
        /// <response code="401">Unauthorized. No tienes permiso para ver esta información</response>
        /// <response code="400">BadRequest. Error de solicitud errónea.</response>
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

        /// <summary>
        /// Crea un objeto de tipo Usuario
        /// </summary>
        /// <remarks>Si los requisitos son correctos, el objeto Usuario se creará correctamente (código 200) y devolvera su token. Si el ModelState no es válido la respuesta será BadRequest (código 400).</remarks>
        /// <response code="200">Created. Objeto creado correctamente.</response>        
        /// <response code="400">BadRequest. Error de solicitud errónea.</response>
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<Response<string>>> Register([FromForm] RegisterDto registerUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userDto = await _authBusiness.Register(registerUser);
                if (userDto == null)
                    return new Response<string>(null, false, null, "El usuario ya existe");

                var loginDto = new LoginDto{ Email = registerUser.Email, Password = registerUser.Password};

                var token = await _authBusiness.Login(loginDto);
                
                return new Response<string>(token, true, null, ResponseMessage.Success);
            }
            catch (Exception)
            {
                return new Response<string>(null, false, null, ResponseMessage.Error);
            }
        }

        /// <summary>
        /// Inicia sesión con un usuario registrado.
        /// </summary>
        /// <remarks>Si los requisitos son correctos, se devolvera un token de autenticación (código 200). Si algún dato no corresponde a un usuario registrado la respuesta será NotFound (código 404)</remarks>
        /// <response code="200">Ok. Datos correctos.</response>
        /// <response code="404">NotFound. Algún dato es incorrecto</response>
        /// <response code="400">BadRequest. Error de solicitud errónea.</response>
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
