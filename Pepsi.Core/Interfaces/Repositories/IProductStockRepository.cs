using Pepsi.Core.Entity;

namespace Pepsi.Core.Interfaces.Repositories;

public interface IProductStockRepository : IRepository<ProductStock>
{
    Task<ProductStock?> GetStockByProductIdAsync(int productId);
}
