using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure.DatabaseAccess;

namespace Pepsi.Infrastructure.Repositories;

public class ProductStockRepository : GenericRepository<ProductStock>, IProductStockRepository
{
    public ProductStockRepository(IDatabaseAccessor dbAccessor) : base(dbAccessor, "ProductStocks")
    {
    }

    public async Task<ProductStock?> GetStockByProductIdAsync(int productId)
    {
        var sql = "SELECT * FROM ProductStocks WHERE ProductId = @ProductId";
        return await DbAccessor.QuerySingleOrDefaultAsync<ProductStock>(sql, new { ProductId = productId });
    }




}
