using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Controllers;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngProjectTests.Controllers
{
    [TestClass()]
    public class UsersControllerTests : BaseTest
    {
        #region GetByIdTests
        [TestMethod]
        public async Task GetUserById_Ok_Test()
        {
            //Arrange
            var id = 1;
            var userServices = GetUserBusiness();
            var user = await userServices.GetById(id);

            var controler = new UserController(userServices);
            controler.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var resp = await controler.GetById(id);
            var result = (resp as OkObjectResult)?.Value as Response<UserDto>;

            //Assett
            Assert.IsTrue(result?.Succeeded);
            Assert.AreEqual(user.Id, result?.Data.Id);
        }

        [TestMethod]
        public async Task GetUserById_NotFound_Test()
        {
            //Arrange
            var id = 12549;
            var userServices = GetUserBusiness();

            var controler = new UserController(userServices);
            controler.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var resp = await controler.GetById(id);
            var result = (resp as NotFoundObjectResult)?.Value as Response<UserDto>;

            //Assett
            Assert.IsInstanceOfType(resp, typeof(NotFoundObjectResult));
            Assert.IsFalse(result?.Succeeded);
            Assert.IsNull(result?.Data);
        }

        [TestMethod]
        public async Task GetUserById_BadRequest_Test()
        {
            //Arrange
            var id = 1;
            var controler = new UserController(null);
            controler.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var resp = await controler.GetById(id);
            var result = (resp as BadRequestObjectResult)?.Value as Response<UserDto>;

            //Assett
            Assert.IsInstanceOfType(resp, typeof(BadRequestObjectResult));
            Assert.IsFalse(result?.Succeeded);
        }
        #endregion

        #region GetAllTests
        [TestMethod()]
        public async Task GetAllUsers_Ok_Test()
        {
            //Arrange
            var userServices = GetUserBusiness();
            var list = await userServices.GetAll();

            var controller = new UserController(userServices);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var resp = await controller.GetAll();
            var result = ((resp.Result) as OkObjectResult)?.Value as List<UserDto>;

            //Assert
            Assert.AreEqual(list?.Count(), result?.Count());
        }

        [TestMethod()]
        public async Task GetAllUsers_BadRequest_Test()
        {
            //Arrange
            var userServices = GetUserBusiness();

            var controller = new UserController(null);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var resp = await controller.GetAll();
            var result = ((resp.Result) as BadRequestObjectResult)?.Value;

            //Assert
            Assert.IsInstanceOfType(resp.Result, typeof(BadRequestObjectResult));
            Assert.IsInstanceOfType(result, typeof(string));
        }
        #endregion

        #region UpdateTests
        [TestMethod]
        public async Task UpdateUser_ValidationErrors_Tests()
        {
            //Arrange
            var id = 1;
            var userServices = GetUserBusiness();
            var user = new UserEditDto()
            {
                FirstName = null,
                LastName = "Hernandez",
                Email = "pruebatests@gmail.com",
                Photo = GetMockJPG()
            };
                

            var controller = new UserController(userServices);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ObjectValidator = new ObjectValidator();

            //Act
            controller.TryValidateModel(user);
            var resp = await controller.Update(id, user);
            var result = ((resp.Result) as BadRequestObjectResult)?.Value as Response<UserDto>;

            //Assert
            Assert.IsInstanceOfType(resp.Result, typeof(BadRequestObjectResult));
            Assert.IsFalse(result?.Succeeded);
            Assert.IsNotNull(result?.Errors);
        }

        [TestMethod]
        public async Task UpdateUser_NotFound_Tests()
        {
            //Arrange
            var id = 1524855;
            var userServices = GetUserBusiness();
            var user = new UserEditDto()
            {
                FirstName = "María",
                LastName = "Hernandez",
                Email = "pruebatests@gmail.com",
                Photo = GetMockJPG()
            };


            var controller = new UserController(userServices);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ObjectValidator = new ObjectValidator();

            //Act
            controller.TryValidateModel(user);
            var resp = await controller.Update(id, user);
            var result = ((resp.Result) as NotFoundObjectResult)?.Value as Response<UserDto>;

            //Assert
            Assert.IsInstanceOfType(resp.Result, typeof(NotFoundObjectResult));
            Assert.IsFalse(result?.Succeeded);
        }

        [TestMethod]
        public async Task UpdateUser_Ok_Tests()
        {
            //Arrange
            var id = 1;
            var userServices = GetUserBusiness();
            var user = new UserEditDto()
            {
                FirstName = "María",
                LastName = "Hernandez",
                Email = "pruebatests@gmail.com",
                Photo = GetMockJPG()
            };


            var controller = new UserController(userServices);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var resp = await controller.Update(id, user);
            var result = ((resp.Result) as OkObjectResult)?.Value as Response<UserDto>;

            //Assert
            Assert.IsInstanceOfType(resp.Result, typeof(OkObjectResult));
            Assert.IsTrue(result?.Succeeded);
            Assert.AreEqual(user.Email, result?.Data?.Email);
        }

        [TestMethod]
        public async Task UpdateUser_BadRequest_Tests()
        {
            //Arrange
            var id = 1;
            var userServices = GetUserBusiness();
            var user = new UserEditDto()
            {
                FirstName = "María",
                LastName = "Hernandez",
                Email = "pruebatests@gmail.com",
                Photo = GetMockJPG()
            };


            var controller = new UserController(null);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var resp = await controller.Update(id, user);
            var result = ((resp.Result) as BadRequestObjectResult)?.Value as Response<UserDto>;

            //Assert
            Assert.IsInstanceOfType(resp.Result, typeof(BadRequestObjectResult));
            Assert.IsFalse(result?.Succeeded);
        }
        #endregion

        #region DeleteTests
        [TestMethod]
        public async Task DeleteUser_Ok_Tests()
        {
            //Arrange
            var id = 1;
            var userServices = GetUserBusiness();
            
            var controller = new UserController(userServices);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var resp = await controller.Delete(id);
            var result = ((resp.Result) as OkObjectResult)?.Value as Response<User>;

            var user = await userServices.GetById(id);

            //Assert
            Assert.IsInstanceOfType(resp.Result, typeof(OkObjectResult));
            Assert.IsTrue(result?.Succeeded);
            Assert.IsNull(user);
        }

        [TestMethod]
        public async Task DeleteUser_NotFound_Tests()
        {
            //Arrange
            var id = 146651;
            var userServices = GetUserBusiness();

            var controller = new UserController(userServices);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var resp = await controller.Delete(id);
            var result = ((resp.Result) as NotFoundObjectResult)?.Value as Response<User>;

            var user = await userServices.GetById(id);

            //Assert
            Assert.IsInstanceOfType(resp.Result, typeof(NotFoundObjectResult));
            Assert.IsFalse(result?.Succeeded);
            Assert.IsNull(user);
        }
        #endregion
    }
}
