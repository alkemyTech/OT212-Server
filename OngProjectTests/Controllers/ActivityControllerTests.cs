using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Controllers;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngProjectTests.Controllers
{
    [TestClass()]
    public class ActivityControllerTests : BaseTest
    {
        [TestMethod]
        public async Task InsertActivity_Ok_Tests()
        {
            //Arrange
            var activityServices = GetActivityBusiness();
            var activity = new ActivityInsertDto()
            {
                Name = "asdasd",
                Content = "asdsadsa",
                Image = GetMockJPG()
            };

            var controller = new ActivityController(activityServices);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ObjectValidator = new ObjectValidator();

            //Act
            var resp = await controller.Insert(activity);

            //Assert
            Assert.IsInstanceOfType(resp.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task InsertActivity_BadRequest_Tests()
        {
            //Arrange
            var activityServices = GetActivityBusiness();
            var activity = new ActivityInsertDto()
            {
                Name = "Actividad",
                Content = "contenido",
                Image = GetMockJPG()
            };

            var controller = new ActivityController(null);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ObjectValidator = new ObjectValidator();

            //Act
            var resp = await controller.Insert(activity);

            //Assert
            Assert.IsInstanceOfType(resp.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task UpdateActivity_Ok_Tests()
        {
            //Arrange
            var id = 1;
            var activityServices = GetActivityBusiness();
            var activity = new ActivityUpdateDto()
            {
                Name = "Programas Educativos",
                Content = "Mediante nuestros programas educativos, buscamos incrementar la capacidad intelectual, " +
                    "moral y afectiva de las personas de acuerdo con la cultura y las normas de convivencia de la " +
                    "sociedad a la que pertenecen.",
                Image = GetMockJPG()
            };


            var controller = new ActivityController(activityServices);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var resp = await controller.Update(activity, id);

            //Assert
            Assert.IsInstanceOfType(resp.Result, typeof(OkObjectResult));
        }

        [TestMethod()]
        public async Task UpdateActivity_NotFound_Tests()
        {
            //Arrange
            var id = 12312;
            var activityServices = GetActivityBusiness();
            var activity = new ActivityUpdateDto()
            {
                Name = "Programas Educativos",
                Content = "Mediante nuestros programas educativos, buscamos incrementar la capacidad intelectual, " +
                    "moral y afectiva de las personas de acuerdo con la cultura y las normas de convivencia de la " +
                    "sociedad a la que pertenecen.",
                Image = GetMockJPG()
            };

            var controller = new ActivityController(activityServices);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ObjectValidator = new ObjectValidator();

            //Act
            controller.TryValidateModel(activity);
            var resp = await controller.Update(activity, id);

            //Assert
            Assert.IsInstanceOfType(resp.Result, typeof(NotFoundObjectResult));
        }
    }
}
