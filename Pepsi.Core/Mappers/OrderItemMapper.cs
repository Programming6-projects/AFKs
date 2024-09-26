using System.Diagnostics;
using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;

namespace Pepsi.Core.Mappers;


public class OrderItemMapper(IMapper<Product, ProductDto> productMapper) : IMapper<OrderItem, OrderItemDto>, IMapper<OrderItem, CompleteOrderItemDto>
{
    public OrderItemDto MapToDto(OrderItem entity)
    {
        Debug.Assert(entity != null, nameof(entity) + " != null");
        return new OrderItemDto
        {
            Id = entity.Id,
            OrderId = entity.OrderId,
            ProductId = entity.ProductId,
            Quantity = entity.Quantity
        };
    }

    public CompleteOrderItemDto MapToCompleteDto(OrderItem entity)
    {
        Debug.Assert(entity != null, nameof(entity) + " != null");
        return new CompleteOrderItemDto
        {
            Id = entity.Id,
            OrderId = entity.OrderId,
            ProductId = entity.ProductId,
            Product = entity.Product,
            Quantity = entity.Quantity,
        };
    }

    CompleteOrderItemDto IMapper<OrderItem, CompleteOrderItemDto>.MapToDto(OrderItem entity)
    {
        return MapToCompleteDto(entity);
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

    public OrderItem MapToEntity(CompleteOrderItemDto dto)
    {
        Debug.Assert(dto != null, nameof(dto) + " != null");
        return new OrderItem
        {
            Id = dto.Id,
            OrderId = dto.OrderId,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            // Note: We don't set the Product property here as it's not typically
            // needed when mapping from DTO to Entity for persistence
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

    public Task<OrderItem> MapFromCreateToEntity(CompleteOrderItemDto dto)
    {
        Debug.Assert(dto != null, nameof(dto) + " != null");
        return Task.FromResult(new OrderItem
        {
            OrderId = dto.OrderId,
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            // Note: We don't set the Product property here as it's not typically
            // needed when mapping from DTO to Entity for persistence
        });
    }

    public IEnumerable<OrderItemDto> MapToDtoList(IEnumerable<OrderItem> entities) =>
        entities.Select(MapToDto);

    IEnumerable<CompleteOrderItemDto> IMapper<OrderItem, CompleteOrderItemDto>.MapToDtoList(IEnumerable<OrderItem> entities) =>
        entities.Select(MapToCompleteDto);

    public IEnumerable<OrderItem> MapToEntityList(IEnumerable<OrderItemDto> dtos) =>
        dtos.Select(MapToEntity);

    public IEnumerable<OrderItem> MapToEntityList(IEnumerable<CompleteOrderItemDto> dtos) =>
        dtos.Select(MapToEntity);
}
