using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OngProject.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace OngProject.Controllers
{
    [Route("contacts")]
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactBusiness _contactBusiness;
        public ContactsController(IContactBusiness contactBusiness)
        {
            _contactBusiness = contactBusiness;
        }

        [HttpGet]
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
    }
}
