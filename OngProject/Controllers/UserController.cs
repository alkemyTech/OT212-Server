using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [SwaggerTag("Users", "Web API para usuarios")]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        /// <summary>
        /// Obtiene un objeto de tipo Usuario
        /// </summary>
        /// <remarks>
        /// Devuelve un usuario cuando le ingresas un identificador (id) por parámetro. 
        /// Devuelve un Ok (código 200) si el usuario fue encontrado en la base de datos, 
        /// caso contrario devuelve BadRequest (código 400) si el usuario no existe en la
        /// base de datos.
        /// </remarks>
        /// <param name="id">identificador del usuario a encontrar.</param>
        /// <returns>Objeto de tipo usuario.</returns>
        /// <response code="200">Ok. Devuelve el objeto.</response>
        /// <response code="400">BadRequest. No ha podido devolver el objeto.</response>
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
        /// <summary>
        /// Obtiene todos los usuarios.
        /// </summary>
        /// <remarks>
        /// Devuelve una lista con todos los usuarios que estén registrado en la base de datos.
        /// Devuelve Ok (código 200) si hay usuarios en la base de datos, caso contrario,
        /// Devuelve BadRequest (código 400) sí hubo un problema interno con la base de datos.
        /// </remarks>
        /// <response code="401">Unauthorized. No tienes permiso para ver esta información.</response> 
        /// <response code="200">Ok. Devuelve todos los objetos.</response>
        /// <response code="400">BadRequest. No ha podido devolver ningún objeto.</response>
        /// <returns>Una lista de usuarios</returns>
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

        /// <summary>
        /// Actualiza un objeto de tipo Usuario.
        /// </summary>
        /// <remarks>
        /// Siempre y cuando el objeto exista en la base de datos, se podrá actualizar, 
        /// de lo contrario no se podrá actualizar y mandará un NotFound (código 404) porque 
        /// no se encontró el objeto. Además, es posible que si el objeto ingresado no tiene
        /// el modelo válido o hay un error interno con la base de datos, devolverá un 
        /// BadRequest (código 400).
        /// </remarks>
        /// <param name="id">Identificador del objeto a actualizar.</param>
        /// <param name="user">Objeto a actualizar.</param>
        /// <returns>Devuelve un Response de tipo UserDto</returns>          
        /// <response code="200">Updated. Objeto actualizado correctamente.</response>        
        /// <response code="400">BadRequest. No se ha podido actualizar el objeto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto.</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<UserDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response<UserDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response<UserDto>))]
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

        /// <summary>
        /// Elimina un usuario.
        /// </summary>
        /// <remarks>
        /// Borra a un usuario por la identificación (id) ingresada por parámetro. Devuelve un
        /// Deleted (código 200) si la identificación del usuario coincide con algún usuario
        /// de la base de datos, caso contrario, devuelve un NotFound porque no se encontró 
        /// dicho usuario por la identificación.
        /// </remarks>
        /// <param name="id">identificador del usuario a eliminar.</param>
        /// <returns>Un response de tipo User.</returns>
        /// <response code="200">Deleted. Objeto borrado correctamente.</response> 
        /// <response code="404">NotFound. No se ha encontrado el objeto.</response>
        /// <response code="401">Unauthorized. No tienes permiso para ver esta información.</response> 
        [HttpDelete("{id}")]
        [Authorize(Roles = "Usuario, Administrador")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<User>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response<User>))]
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