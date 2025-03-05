using FIF.Application.Profiles;
using FIF.Application.Services;
using FIF.Domain;
using FIF.Domain.Services;
using FIF.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FIF.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services,  IConfiguration configuration)
        {
            services.RegisterDatabase(configuration);
            services.RegisterIdentity();

            services.AddScoped<IAppDbContext, AppDbContext>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }



        public static IServiceCollection AddCommunAppServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ServiceRegistration).Assembly, typeof(PersonProfile).Assembly);
            return services;
        }
    }
}
