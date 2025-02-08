using FIF.Domain.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FIF.Persistence
{
    public static class ServiceRegistration
    {
        public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var mariaDBSection = configuration.GetRequiredSection(nameof(MariaDBConnection));

            var connectionString = mariaDBSection.Get<MariaDBConnection>()?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "Connection string for MariaDB is missing or empty.");
            }

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
        }

        public static void RegisterIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<User>().AddEntityFrameworkStores<AppDbContext>().AddSignInManager<SignInManager<User>>();
        }
    }
}
