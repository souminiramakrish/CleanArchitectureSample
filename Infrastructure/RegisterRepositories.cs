using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{

    public static class Dependencies
    {
        public static IServiceCollection RegisterRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
