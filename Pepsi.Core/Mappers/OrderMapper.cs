using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Mappers;

namespace Pepsi.Core.Mappers;


public class OrderMapper : IMapper<Order, OrderDto>
{
    private readonly IMapper<OrderItem, OrderItemDto> _orderItemMapper;
    private readonly IMapper<Client, ClientDto> _clientMapper;
    private readonly IMapper<Vehicle, VehicleDto> _vehicleMapper;

    public OrderMapper(IMapper<OrderItem, OrderItemDto> orderItemMapper, IMapper<Client, ClientDto> clientMapper, IMapper<Vehicle, VehicleDto> vehicleMapper)
    {
        _orderItemMapper = orderItemMapper;
        _clientMapper = clientMapper;
        _vehicleMapper = vehicleMapper;
    }

    public OrderDto MapToDto(Order entity) => new OrderDto
    {
        Id = entity.Id,
        ClientId = entity.ClientId,
        Client = entity.Client != null ? _clientMapper.MapToDto(entity.Client) : null,
        VehicleId = entity.VehicleId,
        Vehicle = entity.Vehicle != null ? _vehicleMapper.MapToDto(entity.Vehicle) : null,
        Items = _orderItemMapper.MapToDtoList(entity.Items),
        TotalVolume = entity.TotalVolume,
        OrderDate = entity.OrderDate,
        DeliveryDate = entity.DeliveryDate,
        Status = entity.Status
    };

    public Order MapToEntity(OrderDto dto) => new Order
    {
        Id = dto.Id,
        ClientId = dto.ClientId,
        VehicleId = dto.VehicleId,
        Items = _orderItemMapper.MapToEntityList(dto.Items),
        TotalVolume = dto.TotalVolume,
        OrderDate = dto.OrderDate,
        DeliveryDate = dto.DeliveryDate,
        Status = dto.Status
    };

    public IEnumerable<OrderDto> MapToDtoList(IEnumerable<Order> entities) =>
        entities.Select(MapToDto);

    public IEnumerable<Order> MapToEntityList(IEnumerable<OrderDto> dtos) =>
        dtos.Select(MapToEntity);
}
