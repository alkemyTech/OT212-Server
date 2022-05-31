using Microsoft.Extensions.DependencyInjection;
using OngProject.Core.Business;
using OngProject.Core.Interfaces;
using OngProject.Repositories;

namespace OngProject
{
    public static class ServicesConfig
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<UnitOfWork, UnitOfWork>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IAuthBusiness, AuthBusiness>();
            services.AddScoped<IEmailServices, EmailServices>();

            return services;
        }
    }
}
