using Globus.Test.Domain.Interfaces;
using Globus.Test.Infrastructure.Repositories;
using Globus.Test.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Globus.Test.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ProductDbContext>(options => options.UseNpgsql(connectionString));
        
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddSingleton<IProductCache, ProductCache>();

        return services;
    }
}