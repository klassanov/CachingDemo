using Caching.Demo.Repository.Context;
using Caching.Demo.Repository.Interfaces;
using Caching.Demo.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Caching.Demo.Repository
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationContext, ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("postgres-container"));
            });

            services.AddScoped<IProductsRepository, ProductsRepository>();

            return services;
        }
    }
}
