using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;

public class ProductStockService(
    IProductStockRepository productStockRepository,
    IMapper<ProductStock, ProductStockDto> mapper)
    : IProductStockService
{
    public async Task<IEnumerable<ProductStockDto>> GetAllAsync()
    {
        var stocks = await productStockRepository.GetAllAsync().ConfigureAwait(false);
        return mapper.MapToDtoList(stocks);
    }

    public async Task<ProductStockDto?> GetByIdAsync(int id)
    {
        var stock = await productStockRepository.GetByIdAsync(id).ConfigureAwait(false);
        return stock != null ? mapper.MapToDto(stock) : null;
    }

    public async Task<ProductStockDto?> GetStockByProductIdAsync(int productId)
    {
        var stock = await productStockRepository.GetStockByProductIdAsync(productId).ConfigureAwait(false);
        return stock != null ? mapper.MapToDto(stock) : null;
    }
}
