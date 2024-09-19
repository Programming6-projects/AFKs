using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Mappers;

namespace Pepsi.Core.Mappers;

public class ProductMapper : IMapper<Product, ProductDto>
{
    public ProductDto MapToDto(Product entity)
    {
        return new ProductWithStockDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Price = entity.Price,
            Weight = entity.Weight
        };
    }

    public Product MapToEntity(ProductDto dto)
    {
        return new Product
        {
            Id = dto.Id,
            Name = dto.Name,
            Price = dto.Price,
            Weight = dto.Weight
        };
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

