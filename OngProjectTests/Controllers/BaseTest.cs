using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OngProject;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs;
using OngProject.DataAccess;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace OngProjectTests.Controllers
{
    public class BaseTest
    {
        protected AppDbContext GetDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(dbName).Options;
            var dbContext = new AppDbContext(options);

            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        protected UnitOfWork GetUnitOfWork()
        {
            var unitOfWork = new UnitOfWork(GetDbContext(Guid.NewGuid().ToString()));

            return unitOfWork;
        }

        protected IUserBusiness GetUserBusiness()
        {
            var userBusiness = new UserBusiness(GetUnitOfWork());

            return userBusiness;
        }


        protected IActivityBusiness GetActivityBusiness()
        {
            var activityBusiness = new ActivityBusiness(GetUnitOfWork());
            return activityBusiness;
        }

        protected INewsBusiness GetNewsBusiness()
        {
            var newsBusiness = new NewsBusiness(GetUnitOfWork());

            return newsBusiness;




        protected IFormFile GetMockJPG()
        {
            var content = new byte[] { 0xFF, 0xD8 };
            var fileName = "test.jpg";
            var stream = new MemoryStream(content);

            //create FormFile with desired data
            return new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
        }

        protected HttpClient GetHttpClient()
        {
            var application = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder => {
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                                        d => d.ServiceType ==
                                        typeof(DbContextOptions<AppDbContext>));

                        services.Remove(descriptor);

                        services.AddDbContext<AppDbContext>(options =>
                        {
                            options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                        }, ServiceLifetime.Singleton);
                    });
                });
            
            var dbContext = application.Services.CreateScope()
                                        .ServiceProvider.GetService<AppDbContext>();
            dbContext?.Database.EnsureCreated();

            return application.CreateClient();
        }

        protected async Task HttpClientLogin(HttpClient httpClient, string email, string password)
        {
            string token = "";
            var user = new LoginDto { Email = email, Password = password };
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var resp = await httpClient.PostAsync("auth/login", content);
            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                token = await resp.Content.ReadAsStringAsync();
            }

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        protected IMemberBusiness GetMemberBusiness()
        {
            var memberBusiness = new MemberBusiness(GetUnitOfWork());

            return memberBusiness;


        }
    }
}
