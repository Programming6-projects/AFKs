using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure.DatabaseAccess;

namespace Pepsi.Infrastructure.Repositories;

public class ProductStockRepository : GenericRepository<ProductStock>, IProductStockRepository
{
    public ProductStockRepository(IDatabaseAccessor dbAccessor) : base(dbAccessor, "product_stocks")
    {
    }

    // public async Task<ProductStock?> GetStockByProductIdAsync(int productId)
    // {
    //     var sql = "SELECT * FROM product_stocks WHERE product_id = @ProductId";
    //     return await _dbAccessor.QuerySingleOrDefaultAsync<ProductStock>(sql, new { ProductId = productId });
    // }

    public async Task<ProductStock?> GetStockByProductIdAsync(int productId)
    {
        var sql = @"
            SELECT id, quantity_on_hand, quantity_sold, quantity_reserved, product_id
            FROM product_stocks
            WHERE product_id = @ProductId";


        var stock = await DbAccessor.QuerySingleOrDefaultAsync<ProductStock>(sql, new { ProductId = productId }).ConfigureAwait(false);

        return stock;
    }

    public override async Task<IEnumerable<ProductStock>> GetAllAsync()
    {
        var sql = @"
            SELECT id, quantity_on_hand, quantity_sold, quantity_reserved, product_id
            FROM product_stocks";


        var stocks = await DbAccessor.QueryAsync<ProductStock>(sql).ConfigureAwait(false);
        var productStocks = stocks as ProductStock[] ?? stocks.ToArray();
        foreach (var stock in productStocks)
        {
            Console.WriteLine($"Stock: {stock}");
        }

        return productStocks;
    }
}
