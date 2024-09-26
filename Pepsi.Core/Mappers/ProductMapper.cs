using System.Diagnostics;
using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;

namespace Pepsi.Core.Mappers;

public class ProductMapper : IMapper<Product, ProductDto>
{
    public ProductDto MapToDto(Product entity)
    {
        Debug.Assert(entity != null, nameof(entity) + " != null");
        return new ProductWithStockDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            Volume = entity.Volume
        };
    }

    public Product MapToEntity(ProductDto dto)
    {
        Debug.Assert(dto != null, nameof(dto) + " != null");
        return new Product
        {
            Id = dto.Id,
            Name = dto.Name,
            Price = dto.Price,
            Volume = dto.Volume
        };
    }

    public Task<Product> MapFromCreateToEntity(ProductDto dto)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ProductDto> MapToDtoList(IEnumerable<Product> entities)
    {
        return entities.Select(MapToDto).ToList();
    }

    public IEnumerable<Product> MapToEntityList(IEnumerable<ProductDto> dtos)
    {
        return dtos.Select(MapToEntity).ToList();
    }
}

