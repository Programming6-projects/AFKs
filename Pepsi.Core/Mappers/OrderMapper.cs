using System.Diagnostics;
using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;

namespace Pepsi.Core.Mappers;


public class OrderMapper(
    IMapper<OrderItem, OrderItemDto> orderItemMapper,
    IMapper<Client, ClientDto> clientMapper,
    IMapper<Vehicle, VehicleDto> vehicleMapper)
    : IMapper<Order, OrderDto>
{
    public OrderDto MapToDto(Order entity)
    {
        Debug.Assert(entity != null, nameof(entity) + " != null");
        return new OrderDto
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

    public Order MapToEntity(OrderDto dto)
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

    public IEnumerable<OrderDto> MapToDtoList(IEnumerable<Order> entities) =>
        entities.Select(MapToDto);

    public IEnumerable<Order> MapToEntityList(IEnumerable<OrderDto> dtos) =>
        dtos.Select(MapToEntity);
}
