using Pepsi.Core.DTOs;

namespace Pepsi.Core.Interfaces.Services;

public interface IProductService : IReadOnlyService<ProductDto>
{
    Task<IEnumerable<ProductDto>> GetProductsByNameAsync(string name);
    Task<IEnumerable<ProductWithStockDto>> GetAllProductsWithStockAsync();

    Task<ProductWithStockDto?> GetByIdWithStockAsync(int id);
    Task<ProductWithStockDto?> GetProductByIdWithStockAsync(int id);
}
