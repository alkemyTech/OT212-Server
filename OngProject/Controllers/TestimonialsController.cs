using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using System;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [SwaggerTag("Testimonials", "Web API para mantenimiento de Testimonios")]
    [ApiController]
    [Route("api/testimonials")]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialsBussines _testimonailsBussines;

        public TestimonialsController(ITestimonialsBussines testimonailsBussines)
        {
            _testimonailsBussines = testimonailsBussines;
        }

        /// <sumary>
        /// Obtinene una lista de objetos de tipo Testimonials, de forma pagina.
        /// </sumary>
        /// <remarks>Si los requisitos son correctos, la lista de Testimonials se obtendrá correctamente (código 200). Si el objeto a obtener no exíste, devuelve NotFound (código 404).
        /// Si hay una solicitud incorrecta, devuelve BadRequest (error 400). Si no está autorizado, devuelve Unauthorized (código 401).</remarks>
        /// /// <param name="page">Número de página a obtener.</param>
        /// /// <param name="pageSize">Cantidad de objetos en la página.</param>
        /// <response code="401">Unauthorized. No tienes permiso para ver esta información.</response>
        /// <response code="200">Ok. Objeto obtenido correctamente.</response>
        /// <response code="400">BadRequest. Error de solicitud.</response>
        [HttpGet]
        public async Task<ActionResult> GetAll(int page, int pageSize = 10)
        {
            try
            {
                if (pageSize < 1 || page < 1)
                    return BadRequest("Incorrect page or size number.");

                var elemntsCount = await _testimonailsBussines.CountElements();
                var higherPageNumber = (int)Math.Ceiling(elemntsCount / (double)pageSize);

                if (page > higherPageNumber)
                    return BadRequest($"Incorrect page. Max page number is {higherPageNumber}.");

                var tetismonialList = await _testimonailsBussines.GetAll(page, pageSize, $"{Request.Host}{Request.Path}");

                if (tetismonialList.Items.Count == 0)
                    return NotFound("Testimonial list is empty.");

                return Ok(tetismonialList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"TestimonialsController.GetAll: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Inserta un objeto de tipo Testimonials
        /// </summary>
        /// <remarks>Si los requisitos son correctos, el objeto Testimonials se creará correctamente (código 201). Si el ModelState no es válido la respuesta será BadRequest (código 400).
        /// Si no está autorizado, devuelve Unauthorized (error 401).
        /// Solo un Administrador puede insertar testimonios.</remarks>
        /// <response code="401">Unauthorized. No autorizado para hacer este pedido.</response>              
        /// <response code="201">Created. Objeto creado correctamente.</response>        
        /// <response code="400">BadRequest. Error de solicitud errónea.</response>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<TestimonialDto>> Insert([FromForm] TestimonialCreationDto creationDto)
        {
            var response = await _testimonailsBussines.Insert(creationDto);

            if (!response.Succeeded)
                return BadRequest(response);
                
            return Ok(response.Data);
        }

        /// <summary>
        /// Actualiza un objeto de tipo Testimonials
        /// </summary>
        /// <param name="id">Id del objeto a actualizar.</param>
        /// <remarks>Si los requisitos son correctos, el objeto Testimonials se actualizará correctamente (código 200). Si el objeto a actualizar o alguna otra entidad necesaria no existe, devuelve NotFound (código 404).
        /// Si hay una solicitud incorrecta, devuelve BadRequest (error 400). Si no está autorizado, devuelve Unauthorized (error 401).
        /// Solo un administrador puede actualizar testimonios.</remarks>
        /// <response code="401">Unauthorized. No tienes autorización.</response>              
        /// <response code="200">OK. Objeto actualizado correctamente.</response>        
        /// <response code="400">BadRequest. No se ha podido actualizar el objeto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto.</response>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<Response<TestimonialDto>>> Update(int id, [FromForm] TestimonialCreationDto testimonialDto)
        {
            var response = await _testimonailsBussines.Update(id, testimonialDto);
            if (response.Succeeded)
                return Ok(response);
            return BadRequest(response);
        }

        /// <summary>
        /// Borra un objeto de tipo Testimonials, haciendo un borrado lógico.
        /// </summary>
        /// <remarks>Si los requisitos son correctos, el objeto Testimonials se elimina correctamente (código 200). Si el objeto a eliminar no existe, devuelve NotFound (código 404).
        /// Si hay una solicitud incorrecta, devuelve BadRequest (error 400). Si no está autorizado, devuelve Unauthorized (error 401).
        /// Solo un administrador puede eliminar testimonios.</remarks>
        /// <param name="id">Id del objeto a eliminar.</param>
        /// <response code="401">Unauthorized. No tienes permiso para ver esta información.</response>              
        /// <response code="200">OK. Objeto eliminado correctamente.</response>        
        /// <response code="400">BadRequest. No se ha podido eliminar el objeto.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto.</response>
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult<TestimonialDto>> Delete(int id)
        {
            var response = await _testimonailsBussines.Delete(id);

            if (response.Message == "Record not found")
                return NotFound(response);

            if (!response.Succeeded)
                return BadRequest(response);

            return Ok(response.Data);
        }
    }
}