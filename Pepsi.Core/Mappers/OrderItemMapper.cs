using System.Diagnostics;
using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;

namespace Pepsi.Core.Mappers;


public class OrderItemMapper(IMapper<Product, ProductDto> productMapper) : IMapper<OrderItem, OrderItemDto>
{
    public OrderItemDto MapToDto(OrderItem entity)
    {
        Debug.Assert(entity != null, nameof(entity) + " != null");
        return new OrderItemDto
        {
            Id = entity.Id,
            OrderId = entity.OrderId,
            ProductId = entity.ProductId,
            Quantity = entity.Quantity,
        };
    }

    public OrderItem MapToEntity(OrderItemDto dto)
    {
        Debug.Assert(dto != null, nameof(dto) + " != null");
        return new OrderItem
        {
            Id = dto.Id,
            OrderId = dto.OrderId,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
        };
    }

    public Task<OrderItem> MapFromCreateToEntity(OrderItemDto dto)
    {
        Debug.Assert(dto != null, nameof(dto) + " != null");
        return Task.FromResult(new OrderItem
        {
            OrderId = dto.OrderId,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
        });
    }

    public IEnumerable<OrderItemDto> MapToDtoList(IEnumerable<OrderItem> entities) =>
        entities.Select(MapToDto);


    public IEnumerable<OrderItem> MapToEntityList(IEnumerable<OrderItemDto> dtos) =>
        dtos.Select(MapToEntity);
}
