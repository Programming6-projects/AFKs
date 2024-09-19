using Pepsi.Core.DTOs;

namespace Pepsi.Core.Interfaces.Services;

public interface IProductStockService : IReadOnlyService<ProductStockDto>
{
    Task<ProductStockDto?> GetStockByProductIdAsync(int productId);
}
