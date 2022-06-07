using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactBusiness _contactBusiness;
        public ContactsController(IContactBusiness contactBusiness)
        {
            _contactBusiness = contactBusiness;
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetAll()
        {
            var contacts = await _contactBusiness.GetAll();
            try
            {
                if(contacts.Count == 0)
                {
                    return NotFound();
                }
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"ContactsController.Get: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Usuario, Administrador")]
        public async Task<ActionResult<Response<ContactDto>>> Insert(ContactDto contactDto)
        {
            await _contactBusiness.Insert(contactDto);
            return new Response<ContactDto>(null, true, null, ResponseMessage.Success);
        }
    }
}
