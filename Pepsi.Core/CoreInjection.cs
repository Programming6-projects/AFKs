using Microsoft.Extensions.DependencyInjection;
using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Services;
using Pepsi.Core.Mappers;
using Pepsi.Core.Services;

public static class CoreInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        // Services
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductStockService, ProductStockService>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<IVehicleService, VehicleService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<IOrderService, OrderService>();

        // Mappers
        services.AddScoped<IMapper<Product, ProductDto>, ProductMapper>();
        services.AddScoped<IMapper<ProductStock, ProductStockDto>, ProductStockMapper>();
        services.AddScoped<IMapper<Client, ClientDto>, ClientMapper>();
        services.AddScoped<IMapper<Vehicle, VehicleDto>, VehicleMapper>();

        // Order mappers
        services.AddScoped<OrderMapper>();
        services.AddScoped<IMapper<Order, OrderDto>>(sp => sp.GetRequiredService<OrderMapper>());
        services.AddScoped<IMapper<Order, CompleteOrderDto>>(sp => sp.GetRequiredService<OrderMapper>());

        // OrderItem mappers
        services.AddScoped<OrderItemMapper>();
        services.AddScoped<IMapper<OrderItem, OrderItemDto>>(sp => sp.GetRequiredService<OrderItemMapper>());
        services.AddScoped<IMapper<OrderItem, CompleteOrderItemDto>>(sp => sp.GetRequiredService<OrderItemMapper>());

        return services;
    }
}
