using Microsoft.Extensions.DependencyInjection;
using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Services;
using Pepsi.Core.Mappers;
using Pepsi.Core.Services;

namespace Pepsi.Core;

public static class CoreInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductStockService, ProductStockService>();

        services.AddScoped<IClientService, ClientService>();

        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderItemService, OrderItemService>();

        services.AddScoped<IMapper<Product, ProductDto>, ProductMapper>();
        services.AddScoped<IMapper<ProductStock, ProductStockDto>, ProductStockMapper>();
        services.AddScoped<IMapper<Client, ClientDto>, ClientMapper>();
        services.AddScoped<IMapper<Vehicle, VehicleDto>, VehicleMapper>();
        services.AddScoped<IMapper<Order, OrderDto>, OrderMapper>();
        services.AddScoped<IMapper<OrderItem, OrderItemDto>, OrderItemMapper>();

        return services;
    }

}
