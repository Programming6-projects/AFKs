using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductStockService _productStockService;
    private readonly IMapper<Product, ProductDto> _productMapper;
    private readonly IMapper<ProductStock, ProductStockDto> _stockMapper;

    public ProductService(
        IProductRepository productRepository,
        IProductStockService productStockService,
        IMapper<Product, ProductDto> productMapper,
        IMapper<ProductStock, ProductStockDto> stockMapper)
    {
        _productRepository = productRepository;
        _productStockService = productStockService;
        _productMapper = productMapper;
        _stockMapper = stockMapper;
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync().ConfigureAwait(false);
        return _productMapper.MapToDtoList(products);
    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id).ConfigureAwait(false);
        return product == null ? null : _productMapper.MapToDto(product);
    }

    public async Task<IEnumerable<ProductDto>> GetProductsByNameAsync(string name)
    {
        var products = await _productRepository.GetProductsByNameAsync(name).ConfigureAwait(false);
        return _productMapper.MapToDtoList(products);
    }

    public async Task<IEnumerable<ProductWithStockDto>> GetAllProductsWithStockAsync()
    {
        var products = await _productRepository.GetAllAsync().ConfigureAwait(false);
        var productDtos = new List<ProductWithStockDto>();

        foreach (var product in products)
        {
            var productDto = _productMapper.MapToDto(product) as ProductWithStockDto;

            if (productDto != null)
            {
                var stockDto = await _productStockService.GetStockByProductIdAsync(product.Id).ConfigureAwait(false);
                productDto.Stock = stockDto;
                productDtos.Add(productDto);
            }
        }

        return productDtos;
    }

    public async Task<ProductWithStockDto?> GetProductByIdWithStockAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id).ConfigureAwait(false);
        if (product == null)
        {
            return null;
        }

        var productDto = _productMapper.MapToDto(product) as ProductWithStockDto;

        if (productDto != null)
        {
            var stockDto = await _productStockService.GetStockByProductIdAsync(id).ConfigureAwait(false);
            productDto.Stock = stockDto;
        }

        return productDto;
    }
}
