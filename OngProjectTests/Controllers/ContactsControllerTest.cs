using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProjectTests.Controllers;

namespace OngProject.Controllers.Tests
{
    [TestClass()]
    public class ContactsControllerTest : BaseTest
    {
        [TestMethod()]
        public async Task GetAllContactAsUser()
        {
            string email = "prueba11@gmail.com";
            string pass = "1234";

            var client = GetHttpClient();
            await HttpClientLogin(client, email, pass);

            var result = await client.GetAsync("/contacts");

            Assert.AreEqual(403, (int)result.StatusCode);
        }

        [TestMethod()]
        public async Task GetAllContactAsAdmin()
        {
            string email = "prueba2@gmail.com";
            string pass = "1234";

            var client = GetHttpClient();
            await HttpClientLogin(client, email, pass);
            var result = await client.GetAsync("/contacts");

            Assert.AreEqual(404, (int)result.StatusCode); //Porque la lista de contactos está vacía
        }

        [TestMethod()]
        public async Task GetAllContactNotFound()
        {

            /* Debe de complir las siguiente condición:
             * No debe haber ningún contacto en la base de datos.
             */
            IContactBusiness contactBusiness = GetContactBusiness();

            ContactsController contactsController = new ContactsController(contactBusiness);
            contactsController.ControllerContext.HttpContext = new DefaultHttpContext();

            var contactAction = await contactsController.GetAll();
            var resultAction =  contactAction as NotFoundResult;
            Assert.AreEqual(resultAction?.StatusCode, 404);

        }

        [TestMethod()]
        public async Task GetAllContactOk()
        {
            /* Debe de cumplir la siguiente condición:
             * Debe de tener por lo menos un dato en la base de datos:
             */

            IContactBusiness contactBusiness = GetContactBusiness();

            // Creamos un objeto para introducirlo en la base de datos:
            ContactDto contactDto = new ContactDto()
            {
                Name = "Johan",
                Phone = 123456,
                Email = "johansanchezdeleon@gmail.com",
                Message = "Bienvenido señor Johan"

            };

            await contactBusiness.Insert(contactDto);

            ContactsController contactsController = new ContactsController(contactBusiness);
            contactsController.ControllerContext.HttpContext = new DefaultHttpContext();

            var contactAction = await contactsController.GetAll();
            var resultAction = contactAction as OkObjectResult;
            Assert.AreEqual(resultAction?.StatusCode, 200);
        }

        [TestMethod()]
        public async Task InsertContactOk()
        {
            IContactBusiness contactBusiness = GetContactBusiness();

            ContactsController contactsController = new ContactsController(contactBusiness);
            contactsController.ControllerContext.HttpContext = new DefaultHttpContext();

            ContactDto contactDto = new ContactDto()
            {
                Name = "Johan",
                Phone = 1234,
                Email = "johansanchezdeleon@gmail.com",
                Message = "Prueba"
            };

            var responseAction = await contactsController.Insert(contactDto);

            var resultResponse = responseAction.Value;
            Assert.AreEqual(true, resultResponse?.Succeeded);

        }
    }
}
