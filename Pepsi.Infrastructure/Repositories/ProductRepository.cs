using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure.DatabaseAccess;
using Pepsi.Core.Entities;

namespace Pepsi.Infrastructure.Repositories;

public class ProductRepository(IDatabaseAccessor dbAccessor)
    : GenericRepository<Product>(dbAccessor, "Products"), IProductRepository
{
    public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
    {
        const string sql = "SELECT * FROM Products WHERE Name LIKE @Name";
        return await DbAccessor.QueryAsync<Product>(sql, new { Name = $"%{name}%" }).ConfigureAwait(false);
    }
}
