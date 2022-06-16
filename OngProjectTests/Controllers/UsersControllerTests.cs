using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Controllers;
using OngProject.Core.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OngProjectTests.Controllers.Tests
{
    [TestClass()]
    public class UsersControllerTests : BaseTest
    {
        [TestMethod()]
        public async Task GetUserTest()
        {
            //Arrange
            var userServices = GetUserBusiness();
            var list = await userServices.GetAll();

            var Controller = new UserController(userServices);
            Controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var resp = await Controller.GetAll();
            var result = ((resp.Result) as OkObjectResult)?.Value as List<UserDto>;

            //Assert
            Assert.AreEqual(list?.Count(), result?.Count());
        }
    }
}