using System.Diagnostics;
using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;

namespace Pepsi.Core.Mappers;


public class ProductStockMapper : IMapper<ProductStock, ProductStockDto>
{
    public ProductStockDto MapToDto(ProductStock entity)
    {
        Debug.Assert(entity != null, nameof(entity) + " != null");
        return new ProductStockDto
        {
            Id = entity.Id,
            QuantityOnHand = entity.QuantityOnHand,
            QuantitySold = entity.QuantitySold,
            QuantityReserved = entity.QuantityReserved,
            ProductId = entity.ProductId
        };
    }

    public ProductStock MapToEntity(ProductStockDto dto)
    {
        Debug.Assert(dto != null, nameof(dto) + " != null");
        return new ProductStock
        {
            Id = dto.Id,
            QuantityOnHand = dto.QuantityOnHand,
            QuantitySold = dto.QuantitySold,
            QuantityReserved = dto.QuantityReserved,
            ProductId = dto.ProductId
        };
    }

    public IEnumerable<ProductStockDto> MapToDtoList(IEnumerable<ProductStock> entities)
    {
        return entities.Select(MapToDto);
    }

    public IEnumerable<ProductStock> MapToEntityList(IEnumerable<ProductStockDto> dtos)
    {
        return dtos.Select(MapToEntity);
    }
}
