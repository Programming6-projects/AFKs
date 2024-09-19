using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Mappers;

namespace Pepsi.Core.Mappers;


public class OrderItemMapper : IMapper<OrderItem, OrderItemDto>
{
    private readonly IMapper<Product, ProductDto> _productMapper;

    public OrderItemMapper(IMapper<Product, ProductDto> productMapper)
    {
        _productMapper = productMapper;
    }

    public OrderItemDto MapToDto(OrderItem entity) => new OrderItemDto
    {
        Id = entity.Id,
        OrderId = entity.OrderId,
        ProductId = entity.ProductId,
        Product = entity.Product != null ? _productMapper.MapToDto(entity.Product) : null,
        Quantity = entity.Quantity,
        UnitPrice = entity.UnitPrice
    };

    public OrderItem MapToEntity(OrderItemDto dto) => new OrderItem
    {
        Id = dto.Id,
        OrderId = dto.OrderId,
        ProductId = dto.ProductId,
        Quantity = dto.Quantity,
        UnitPrice = dto.UnitPrice
    };

    public IEnumerable<OrderItemDto> MapToDtoList(IEnumerable<OrderItem> entities) =>
        entities.Select(MapToDto);

    public IEnumerable<OrderItem> MapToEntityList(IEnumerable<OrderItemDto> dtos) =>
        dtos.Select(MapToEntity);
}
