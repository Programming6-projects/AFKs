using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure.DatabaseAccess;

namespace Pepsi.Infrastructure.Repositories;

public class ProductStockRepository(IDatabaseAccessor dbAccessor)
    : GenericRepository<ProductStock>(dbAccessor, "ProductStocks"), IProductStockRepository
{
    public async Task<ProductStock?> GetStockByProductIdAsync(int productId)
    {
        const string sql = "SELECT * FROM ProductStocks WHERE ProductId = @ProductId";
        return await DbAccessor.QuerySingleOrDefaultAsync<ProductStock>(sql, new { ProductId = productId }).ConfigureAwait(true);
    }
}
