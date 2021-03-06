using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.DataAccess;
using OngProject.Middleware;
using OngProject.Repositories;


namespace OngProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void AddAppServices(IServiceCollection services)
        {
            services.AddTransient<UnitOfWork>();

            services.AddTransient<IContactBusiness, ContactBusiness>();
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
            services.AddTransient<IEmailServices, EmailServices>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddAppServices(services);

            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OngProject", Version = "v1" });

                // Add Swagger Doc;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Introduzca 'Bearer' [space] y despu?s un token v?lido.",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
            });

            var appSettings = Configuration.GetSection("JWT").GetSection("Secret");
            var key = Encoding.UTF8.GetBytes(appSettings.Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,

                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(c=> c.RouteTemplate = "/api/docs/{documentName}/swagger.json");
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/api/docs/v1/swagger.json", "OngProject v1");
                    c.RoutePrefix = "api/docs";
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UsePersistActionsRestrictions();

            app.UseOwnershipRestrictions();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
