using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;

public class ProductService(
    IProductRepository productRepository,
    IProductStockService productStockService,
    IMapper<Product, ProductDto> productMapper)
    : IProductService
{
    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await productRepository.GetAllAsync().ConfigureAwait(false);
        return productMapper.MapToDtoList(products);
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id).ConfigureAwait(false);
        return product == null ? null : productMapper.MapToDto(product);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByNameAsync(string name)
    {
        var products = await productRepository.GetProductsByNameAsync(name).ConfigureAwait(false);
        return productMapper.MapToDtoList(products);
    }

    public async Task<IEnumerable<ProductWithStockDto>> GetAllProductsWithStockAsync()
    {
        var products = await productRepository.GetAllAsync().ConfigureAwait(false);
        var productDtos = new List<ProductWithStockDto>();

        foreach (var product in products)
        {
            if (productMapper.MapToDto(product) is not ProductWithStockDto productDto)
            {
                continue;
            }

            var stockDto = await productStockService.GetStockByProductIdAsync(product.Id).ConfigureAwait(false);
            productDto.Stock = stockDto;
            productDtos.Add(productDto);
        }

        return productDtos;
    }

    public async Task<ProductWithStockDto?> GetProductByIdWithStockAsync(int id)
    {
        var product = await productRepository.GetByIdAsync(id).ConfigureAwait(false);
        if (product == null)
        {
            return null;
        }

        var productDto = productMapper.MapToDto(product) as ProductWithStockDto;

        if (productDto == null)
        {
            return productDto;
        }

        var stockDto = await productStockService.GetStockByProductIdAsync(id).ConfigureAwait(false);
        productDto.Stock = stockDto;

        return productDto;
    }
}
