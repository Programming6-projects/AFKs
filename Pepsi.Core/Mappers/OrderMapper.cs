using System.Diagnostics;
using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Mappers;

public class OrderMapper(
    IMapper<OrderItem, CompleteOrderItemDto> orderItemMapper,
    IMapper<OrderItem, OrderItemDto> createOrderItemMapper,
    IMapper<Client, ClientDto> clientMapper,
    IMapper<Vehicle, VehicleDto> vehicleMapper,
    IProductService productService)
    : IMapper<Order, OrderDto>,
      IMapper<Order, CompleteOrderDto>
{
    public OrderDto MapToDto(Order entity)
    {
        Debug.Assert(entity != null, nameof(entity) + " != null");
        return new OrderDto
        {
            Id = entity.Id,
            ClientId = entity.ClientId,
            VehicleId = entity.VehicleId,
            Items = createOrderItemMapper.MapToDtoList(entity.Items),
            DeliveryDate = entity.DeliveryDate
        };
    }

    public CompleteOrderDto MapToCompleteDto(Order entity)
    {
        Debug.Assert(entity != null, nameof(entity) + " != null");
        return new CompleteOrderDto
        {
            Id = entity.Id,
            ClientId = entity.ClientId,
            Client = entity.Client != null ? clientMapper.MapToDto(entity.Client) : null,
            VehicleId = entity.VehicleId,
            Vehicle = entity.Vehicle != null ? vehicleMapper.MapToDto(entity.Vehicle) : null,
            Items = orderItemMapper.MapToDtoList(entity.Items),
            TotalVolume = entity.TotalVolume,
            OrderDate = entity.OrderDate,
            DeliveryDate = entity.DeliveryDate,
            Status = entity.Status
        };
    }

    CompleteOrderDto IMapper<Order, CompleteOrderDto>.MapToDto(Order entity)
    {
        return MapToCompleteDto(entity);
    }

    public Order MapToEntity(OrderDto dto)
    {
        Debug.Assert(dto != null, nameof(dto) + " != null");
        return new Order
        {
            Id = dto.Id,
            ClientId = dto.ClientId,
            VehicleId = dto.VehicleId,
            Items = createOrderItemMapper.MapToEntityList(dto.Items),
            DeliveryDate = dto.DeliveryDate,
        };
    }

    public Order MapToEntity(CompleteOrderDto dto)
    {
        Debug.Assert(dto != null, nameof(dto) + " != null");
        return new Order
        {
            Id = dto.Id,
            ClientId = dto.ClientId,
            VehicleId = dto.VehicleId,
            Items = orderItemMapper.MapToEntityList(dto.Items),
            TotalVolume = dto.TotalVolume,
            OrderDate = dto.OrderDate,
            DeliveryDate = dto.DeliveryDate,
            Status = dto.Status
        };
    }

    public async Task<Order> MapFromCreateToEntity(OrderDto dto)
    {
        Debug.Assert(dto != null, nameof(dto) + " != null");
        var order = new Order
        {
            ClientId = dto.ClientId,
            VehicleId = dto.VehicleId,
            Items = createOrderItemMapper.MapToEntityList(dto.Items),
            OrderDate = DateTime.Today,
            DeliveryDate = dto.DeliveryDate,
            Status = OrderStatus.Pending
        };
        var totalVolume = 0m;
        foreach (var item in order.Items)
        {
            var product = await productService.GetByIdAsync(item.ProductId).ConfigureAwait(false);
            if (product != null)
            {
                totalVolume += product.Weight * item.Quantity;
            }
        }
        order.TotalVolume = totalVolume;

        return order;
    }

    public Task<Order> MapFromCreateToEntity(CompleteOrderDto dto)
    {
        // For CompleteOrderDto, we can use the synchronous MapToEntity method
        // as all required information is already present in the DTO
        return Task.FromResult(MapToEntity(dto));
    }

    public IEnumerable<OrderDto> MapToDtoList(IEnumerable<Order> entities) =>
        entities.Select(MapToDto);

    IEnumerable<CompleteOrderDto> IMapper<Order, CompleteOrderDto>.MapToDtoList(IEnumerable<Order> entities) =>
        entities.Select(MapToCompleteDto);

    public IEnumerable<Order> MapToEntityList(IEnumerable<OrderDto> dtos) =>
        dtos.Select(MapToEntity);

    public IEnumerable<Order> MapToEntityList(IEnumerable<CompleteOrderDto> dtos) =>
        dtos.Select(MapToEntity);
}
