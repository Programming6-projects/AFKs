using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;

public class ProductStockService : IProductStockService
{
    private readonly IProductStockRepository _productStockRepository;
    private readonly IMapper<ProductStock, ProductStockDto> _mapper;

    public ProductStockService(
        IProductStockRepository productStockRepository,
        IMapper<ProductStock, ProductStockDto> mapper)
    {
        _productStockRepository = productStockRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductStockDto>> GetAllAsync()
    {
        var stocks = await _productStockRepository.GetAllAsync().ConfigureAwait(false);
        return _mapper.MapToDtoList(stocks);
    }

    public async Task<ProductStockDto?> GetByIdAsync(int id)
    {
        var stock = await _productStockRepository.GetByIdAsync(id).ConfigureAwait(false);
        return stock != null ? _mapper.MapToDto(stock) : null;
    }

    public async Task<ProductStockDto?> GetStockByProductIdAsync(int productId)
    {
        var stock = await _productStockRepository.GetStockByProductIdAsync(productId).ConfigureAwait(false);
        return stock != null ? _mapper.MapToDto(stock) : null;
    }
}
