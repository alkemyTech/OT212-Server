using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.DataAccess;
using OngProject.Repositories;

namespace OngProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void AddAppServices(IServiceCollection services)
        {
            services.AddTransient<AppDbContext>();
            services.AddTransient<UnitOfWork>();

            services.AddTransient<IActivityBusiness, ActivityBusiness>();
            services.AddTransient<IAuthBusiness, AuthBusiness>();
            services.AddTransient<ICategoryBusiness, CategoryBusiness>();
            services.AddTransient<ICommentBusiness, CommentBusiness>();
            services.AddTransient<IMemberBusiness, MemberBusiness>();
            services.AddTransient<INewsBusiness, NewsBusiness>();
            services.AddTransient<IOrganizationBusiness, OrganizationBusiness>();
            services.AddTransient<IRoleBusiness, RoleBusiness>();
            services.AddTransient<ISlideBusiness, SlideBusiness>();
            services.AddTransient<ITestimonialsBussines, TestimonialsBussines>();
            services.AddTransient<IUserBusiness, UserBusiness>();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            AddAppServices(services);


            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OngProject", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OngProject v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
