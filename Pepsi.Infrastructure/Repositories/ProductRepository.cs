using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure.DatabaseAccess;

using Dapper;

namespace Pepsi.Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(IDatabaseAccessor dbAccessor) : base(dbAccessor, "products")
    {
    }

    public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
    {
        var sql = "SELECT * FROM Products WHERE Name LIKE @Name";
        return await DbAccessor.QueryAsync<Product>(sql, new { Name = $"%{name}%" }).ConfigureAwait(false);
    }
}
