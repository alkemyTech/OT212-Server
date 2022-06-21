using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OngProject.Controllers;
using OngProject.Core.Business;
using OngProject.Core.Models;
using OngProject.Core.Models.DTOs;
using OngProjectTests.Mocks;

namespace OngProjectTests.Controllers
{
    [TestClass]
    public class OrganizationControllerTests : BaseTest
    {
        [TestMethod]
        public async Task GetPublicDataFail_ReturnStatusCode400()
        {
            var organizationBusiness = new OrganizationBusinessMock();
            organizationBusiness.GetResponse = new Response<OrganizationDetailsDto> {
                Data = null,
                Succeeded = false,
                Errors = new string[] { "Error." },
                Message = ResponseMessage.Error
            };
            var organizationController = new OrganizationsController(organizationBusiness);

            var result = (await organizationController.Get()).Result as ObjectResult;

            Assert.AreEqual(400, result.StatusCode);         
        }

        [TestMethod]
        public async Task GetPublicDataSuccess_ReturnStatusCode200()
        {
            var organizationBusiness = new OrganizationBusinessMock();
            organizationBusiness.GetResponse = new Response<OrganizationDetailsDto> {
                Data = null,
                Succeeded = true,
                Errors = null,
                Message = ResponseMessage.Success
            };
            var organizationController = new OrganizationsController(organizationBusiness);

            var result = (await organizationController.Get()).Result as ObjectResult;

            Assert.AreEqual(200, result.StatusCode);         
        }

        [TestMethod]
        public async Task GetPublicDataSuccess_ReturnOrganizationData()
        {
            var organizationBusiness = new OrganizationBusiness(GetUnitOfWork());
            var organizationController = new OrganizationsController(organizationBusiness);

            var result = (await organizationController.Get()).Result as ObjectResult;
            var response = result.Value as Response<OrganizationDetailsDto>;

            Assert.AreEqual("Primera Organización", response.Data.Name);
        }

        [TestMethod]
        public async Task UpdateBusinessFails_ReturnStatusCode400()
        {
            var organizationBusiness = new OrganizationBusinessMock();
            var organizationController = new OrganizationsController(organizationBusiness);
            var organizationUpdateDto = new OrganizationUpdateDto();

            var result = (await organizationController.Update(1,organizationUpdateDto)) as ObjectResult;

            Assert.AreEqual(400, result.StatusCode);
        }

        [TestMethod]
        public async Task UpdateWrongId_ReturnNotFound()
        {
            var organizationBusiness = new OrganizationBusiness(GetUnitOfWork());
            var organizationController = new OrganizationsController(organizationBusiness);
            var organizationUpdateDto = new OrganizationUpdateDto();

            var result = (await organizationController.Update(0,organizationUpdateDto)) as ObjectResult;
            var response = result.Value as Response<OrganizationDto>;

            Assert.AreEqual(ResponseMessage.NotFound, response.Message);      
        }

        [TestMethod]
        public async Task UpdateSuccess_ReturnNewOrganizationData()
        {
            var organizationBusiness = new OrganizationBusiness(GetUnitOfWork());
            var organizationController = new OrganizationsController(organizationBusiness);
            var organizationUpdateDto = new OrganizationUpdateDto
            {
                Name = "testing_name",
                Address = string.Empty,
                Phone = string.Empty,
                Email = string.Empty,
                Image = null,
                WelcomeText = string.Empty,
                AboutUsText = string.Empty,
                FacebookUrl = string.Empty,
                LinkedinUrl = string.Empty,
                InstagramUrl = string.Empty
            };

            var result = (await organizationController.Update(1,organizationUpdateDto)) as ObjectResult;
            var response = result.Value as Response<OrganizationDto>;

            Assert.AreEqual("testing_name", response.Data.Name);
        }

    }
}
