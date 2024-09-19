using Pepsi.Core.Entity;

namespace Pepsi.Core.Interfaces.Repositories;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
}
