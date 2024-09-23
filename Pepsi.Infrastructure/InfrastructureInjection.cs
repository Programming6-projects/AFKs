using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure.DataAccess;
using Pepsi.Infrastructure.DatabaseAccess;
using Pepsi.Infrastructure.FileAccess;
using Pepsi.Infrastructure.Repositories;
using Pepsi.Infrastructure.Serialization;

namespace Pepsi.Infrastructure;

public static class InfrastructureInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IDbConnectionFactory, PostgresConnectionFactory>();
        services.AddScoped<IDatabaseAccessor, DatabaseAccessor>();

        services.AddSingleton<IFileReader, JsonFileReader>();
        services.AddSingleton<ISerializer, JsonSerializer>();

        services.AddScoped(typeof(IDataLoader<>), typeof(JsonFileDataLoader<>));

        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductStockRepository, ProductStockRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();

        return services;
    }
}
