using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Controllers;
using OngProject.Core.Business;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProjectTests.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Controllers.Tests
{
    [TestClass()]
    public class MembersControllerTests : BaseTest
    {
        [TestMethod()]
        [DataRow(1,10,typeof(OkObjectResult))]
        [DataRow(1,-1,typeof(BadRequestObjectResult))]
        public async Task GetAllMembers_WhenCalled_ReturnCorrectType(int page,int pageSize, Type type)
        {
            //Arrange
            var memberServices = GetMemberBusiness();
            var controller = new MembersController(memberServices);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var response = await controller.GetAll(page, pageSize);
            
            //Assert
            Assert.IsInstanceOfType(response.Result, type);
        }

        [TestMethod()]
        public async Task InsertMember_WhenCalled_ReturnOk()
        {
            //Arrange
            var memberServices = GetMemberBusiness();
            var controller = new MembersController(memberServices);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var content = new byte[] { 0xFF, 0xD8 };
            var fileName = "test.jpg";
            var stream = new MemoryStream(content);
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            var memberDto = new MemberInsertDto
            {
                Name = "Member Test",
                Description = "Test",
                Image = file,
                FacebookUrl = "facebook.com/test",
                InstagramUrl = "instagram.com/test",
                LinkedinUrl = "linkedin/test"
            };

            var response = await controller.CreateMember(memberDto);

            //Assert
            Assert.AreEqual(response.Message, ResponseMessage.Success);
        }
        /*
        [TestMethod()]
        [Ignore("Definir si los BadRequest se testean.")]
        public async Task InsertMember_WhenCalled_ReturnError()
        {
            //Arrange
            var memberServices = GetMemberBusiness();
            var controller = new MembersController(memberServices);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var response = await controller.CreateMember(null);

            //Assert
            Assert.AreEqual(response.Message, ResponseMessage.Error);
        }
        */
        [TestMethod()]
        [DataRow(1, typeof(OkObjectResult))]
        [DataRow(999, typeof(NotFoundObjectResult))]
        public async Task UpdateMember_WhenCalled_ReturnCorrectType(int id, Type type)
        {
            //Arrage
            var memberServices = GetMemberBusiness();
            var controller = new MembersController(memberServices);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var content = new byte[] { 0xFF, 0xD8 };
            var fileName = "test.jpg";
            var stream = new MemoryStream(content);
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            var memberDto = new MemberUpdateDto
            {
                Name = "Member Test",
                Description = "Test",
                Image = file,
                FacebookUrl = "facebook.com/test",
                InstagramUrl = "instagram.com/test",
                LinkedinUrl = "linkedin/test"
            };

            var response = await controller.Update(id, memberDto);

            //Act
            Assert.IsInstanceOfType(response.Result, type);
        }

        [TestMethod()]
        public async Task DeleteMember_WhenCalled_ReturnOk()
        {
            //Arrange
            var memberServices = GetMemberBusiness();
            var controller = new MembersController(memberServices);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var response = await controller.DeleteMemeber(1);

            //Assert
            Assert.AreEqual(response.Message, ResponseMessage.Success);
        }

        [TestMethod()]
        public async Task DeleteMember_WhenCalled_ReturnNotFound()
        {
            //Arrange
            var memberServices = GetMemberBusiness();
            var controller = new MembersController(memberServices);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            //Act
            var response = await controller.DeleteMemeber(999);

            //Assert
            Assert.AreEqual(response.Message, ResponseMessage.NotFound);
        }
    }
}
