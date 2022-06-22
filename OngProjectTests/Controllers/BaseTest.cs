using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        private IConfiguration? _config;

        protected IConfiguration Config
        {
            get
            {
                if (_config == null)
                {
                    var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: false);
                    _config = builder.Build();
                }

                return _config;
            }
        }
        public BaseTest()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton(Config);
        }
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


        protected IContactBusiness GetContactBusiness()
        {
            return new ContactBusiness(GetUnitOfWork(), new EmailServices(Config));
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

        protected static HttpClient GetHttpClient()
        {
            var application = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(webHostBuilder => 
                { 
                    webHostBuilder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                                        d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));

                        services.Remove(descriptor!);

                        services.AddDbContext<AppDbContext>(options =>
                        {
                            options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                        }, ServiceLifetime.Singleton);
                    });
                });

            var DbContext = application.Services.CreateScope()
                                       .ServiceProvider.GetService<AppDbContext>();

            DbContext?.Database.EnsureCreated();

            return application.CreateClient();
        }
          
        protected async Task HttpClientLogin(HttpClient httpClient, string email, string password)
        {
            string token = string.Empty;

            var user = new LoginDto { Email = email, Password = password};

            var json = JsonConvert.SerializeObject(user);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var resp = await httpClient.PostAsync("auth/login", content);
            if(resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                token = await resp.Content.ReadAsStringAsync();
            }
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
          
        protected IMemberBusiness GetMemberBusiness()
        {
            var memberBusiness = new MemberBusiness(GetUnitOfWork());

            return memberBusiness;
        }
    }
}
