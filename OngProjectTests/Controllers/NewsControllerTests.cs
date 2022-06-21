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
    public class NewsControllerTests: BaseTest
    {
        [TestMethod()]
        public async Task GetAllNewsTest_Ok()
        {
            // Arrange
            var newsService = GetNewsBusiness();

            var controller = new NewsController(newsService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var resp = await controller.GetAll(1,10);

            // Assert
            Assert.IsInstanceOfType(resp, typeof(OkObjectResult));
        }

        [TestMethod()]
        public async Task GetAllNewsTest_BadRequest()
        {
            // Arrange
            var newsService = GetNewsBusiness();

            var controller = new NewsController(newsService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var resp = await controller.GetAll(1, -1);

            // Assert
            Assert.IsInstanceOfType(resp, typeof(BadRequestObjectResult));
        }

        [TestMethod()]
        public async Task GetNewsTest_Ok()
        {
            // Arrange
            var newsService = GetNewsBusiness();

            var controller = new NewsController(newsService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var resp = await controller.GetById(2);

            // Assert
            Assert.AreEqual(resp.Message, ResponseMessage.Success);
            Assert.IsInstanceOfType(resp, typeof(Response<NewsDto>));

        }

        [TestMethod()]
        public async Task GetNewsTest_NotFound()
        {
            // Arrange
            var newsService = GetNewsBusiness();

            var controller = new NewsController(newsService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var resp = await controller.GetById(999);

            // Assert
            Assert.AreEqual(resp.Message, ResponseMessage.NotFound);
            Assert.IsInstanceOfType(resp, typeof(Response<NewsDto>));

        }

        [TestMethod()]
        public async Task GetNewsTest_BadRequest()
        {
            // Arrange
            var controller = new NewsController(null);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var resp = await controller.GetById(2);

            // Assert
            Assert.AreEqual(resp.Message, ResponseMessage.UnexpectedErrors);
            Assert.IsInstanceOfType(resp, typeof(Response<NewsDto>));

        }

        [TestMethod()]
        public async Task DeleteNewsTest_Ok()
        {
            // Arrange
            var newsService = GetNewsBusiness();

            var controller = new NewsController(newsService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var resp = await controller.Delete(2);

            // Assert
            Assert.AreEqual(resp.Message, ResponseMessage.Success);

        }

        [TestMethod()]
        public async Task DeleteNewsTest_NotFound()
        {
            // Arrange
            var newsService = GetNewsBusiness();

            var controller = new NewsController(newsService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var resp = await controller.Delete(999);

            // Assert
            Assert.AreEqual(resp.Message, ResponseMessage.NotFound);
            Assert.IsInstanceOfType(resp, typeof(Response<NewsDto>));

        }

        [TestMethod()]
        public async Task DeleteNewsTest_BadRequest()
        {
            // Arrange
            var controller = new NewsController(null);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var resp = await controller.Delete(2);

            // Assert
            Assert.AreEqual(resp.Message, ResponseMessage.UnexpectedErrors);
            Assert.IsInstanceOfType(resp, typeof(Response<NewsDto>));

        }

        [TestMethod()]
        public async Task InsertNewsOk()
        {
            // Arrange
            var newsService = GetNewsBusiness();

            var controller = new NewsController(newsService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var content = new byte[] { 0xFF, 0xD8 };
            var fileName = "test.jpg";
            var stream = new MemoryStream(content);

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            var newsDto = new NewsInsertDto
            {
                Name = "Test",
                Content = "Test",
                Image = file,
                CategoryId = 1,
            };

            controller.ObjectValidator = new ObjectValidator();
            controller.TryValidateModel(newsDto);
            var resp = await controller.Insert(newsDto);

            // Assert
            Assert.AreEqual(resp.Message, ResponseMessage.Success);
            Assert.IsInstanceOfType(resp, typeof(Response<NewsDto>));

        }

        [TestMethod()]
        public async Task InsertNews_NullService()
        {
            // Arrange

            var controller = new NewsController(null);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var content = new byte[] { 0xFF, 0xD8 };
            var fileName = "test.jpg";
            var stream = new MemoryStream(content);

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            var newsDto = new NewsInsertDto
            {
                Name = "Test",
                Content = "Test",
                Image = file,
                CategoryId = 1,
            };

            controller.ObjectValidator = new ObjectValidator();
            controller.TryValidateModel(newsDto);
            var resp = await controller.Insert(newsDto);

            // Assert
            Assert.AreEqual(resp.Message, ResponseMessage.UnexpectedErrors);

        }

        [TestMethod()]
        public async Task InsertNews_NullName()
        {
            // Arrange

            var controller = new NewsController(null);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var content = new byte[] { 0xFF, 0xD8 };
            var fileName = "test.jpg";
            var stream = new MemoryStream(content);

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            var newsDto = new NewsInsertDto
            {
                Name = null,
                Content = "Test",
                Image = file,
                CategoryId = 1,
            };

            controller.ObjectValidator = new ObjectValidator();
            controller.TryValidateModel(newsDto);
            var resp = await controller.Insert(newsDto);

            // Assert
            Assert.AreEqual(resp.Message, ResponseMessage.ValidationErrors);

        }

        [TestMethod()]
        public async Task UpdateNews_Ok()
        {
            // Arrange
            var newsService = GetNewsBusiness();

            var controller = new NewsController(newsService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var content = new byte[] { 0xFF, 0xD8 };
            var fileName = "test.jpg";
            var stream = new MemoryStream(content);

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            var newsDto = new NewsInsertDto
            {
                Name = "Test",
                Content = "Test",
                Image = file,
                CategoryId = 1,
            };

            controller.ObjectValidator = new ObjectValidator();
            controller.TryValidateModel(newsDto);
            var resp = await controller.Update(2, newsDto);

            // Assert
            Assert.IsInstanceOfType(resp, typeof(OkObjectResult));
            Assert.IsInstanceOfType(((OkObjectResult) resp).Value, typeof(Response<NewsDto>));

        }

        [TestMethod()]
        public async Task UpdateNews_NotFound()
        {
            // Arrange
            var newsService = GetNewsBusiness();

            var controller = new NewsController(newsService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var content = new byte[] { 0xFF, 0xD8 };
            var fileName = "test.jpg";
            var stream = new MemoryStream(content);

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            var newsDto = new NewsInsertDto
            {
                Name = "Test",
                Content = "Test",
                Image = file,
                CategoryId = 1,
            };

            controller.ObjectValidator = new ObjectValidator();
            controller.TryValidateModel(newsDto);
            var resp = await controller.Update(999, newsDto);

            // Assert
            Assert.IsInstanceOfType(resp, typeof(NotFoundObjectResult));

        }

        [TestMethod()]
        public async Task UpdateNews_NullService()
        {
            // Arrange
            var controller = new NewsController(null);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var content = new byte[] { 0xFF, 0xD8 };
            var fileName = "test.jpg";
            var stream = new MemoryStream(content);

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            var newsDto = new NewsInsertDto
            {
                Name = "Test",
                Content = "Test",
                Image = file,
                CategoryId = 1,
            };

            controller.ObjectValidator = new ObjectValidator();
            controller.TryValidateModel(newsDto);
            var resp = await controller.Update(999, newsDto);

            // Assert
            Assert.IsInstanceOfType(resp, typeof(BadRequestObjectResult));

        }

        [TestMethod()]
        public async Task UpdateNews_NullName()
        {
            // Arrange
            var newsService = GetNewsBusiness();

            var controller = new NewsController(newsService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var content = new byte[] { 0xFF, 0xD8 };
            var fileName = "test.jpg";
            var stream = new MemoryStream(content);

            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            var newsDto = new NewsInsertDto
            {
                Name = null,
                Content = "Test",
                Image = file,
                CategoryId = 1,
            };

            controller.ObjectValidator = new ObjectValidator();
            controller.TryValidateModel(newsDto);
            var resp = await controller.Update(999, newsDto);

            // Assert
            Assert.IsInstanceOfType(resp, typeof(BadRequestObjectResult));

        }

        [TestMethod()]
        public async Task GetCommentsOfNews_Ok()
        {
            // Arrange
            var newsService = GetNewsBusiness();

            var controller = new NewsController(newsService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var resp = await controller.Comments(2);

            // Assert
            Assert.AreEqual(resp.Message, ResponseMessage.Success);
            Assert.IsInstanceOfType(resp, typeof(Response<List<CommentDto>>));
        }

        [TestMethod()]
        public async Task GetCommentsOfNews_NotFound()
        {
            // Arrange
            var newsService = GetNewsBusiness();

            var controller = new NewsController(newsService);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var resp = await controller.Comments(999);

            // Assert
            Assert.AreEqual(resp.Message, ResponseMessage.NotFound);
            Assert.IsInstanceOfType(resp, typeof(Response<List<CommentDto>>));
        }

        [TestMethod()]
        public async Task GetCommentsOfNews_BadRequest()
        {
            // Arrange
            var controller = new NewsController(null);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var resp = await controller.Comments(2);

            // Assert
            Assert.AreEqual(resp.Message, ResponseMessage.UnexpectedErrors);
            Assert.IsInstanceOfType(resp, typeof(Response<List<CommentDto>>));
        }

    }
}
