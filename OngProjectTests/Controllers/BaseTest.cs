﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.DataAccess;
using OngProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected IFormFile GetMockJPG()
        {
            var content = new byte[] { 0xFF, 0xD8 };
            var fileName = "test.jpg";
            var stream = new MemoryStream(content);

            //create FormFile with desired data
            return new FormFile(stream, 0, stream.Length, "id_from_form", fileName);
        }
    }
}
