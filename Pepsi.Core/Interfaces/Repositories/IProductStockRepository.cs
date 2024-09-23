using Pepsi.Core.Entities;

namespace Pepsi.Core.Interfaces.Repositories;

public interface IProductStockRepository : IRepository<ProductStock>
{
    Task<ProductStock?> GetStockByProductIdAsync(int productId);
}
