using Pepsi.Core.Entity;

namespace Pepsi.Core.Interfaces.Repositories;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByClientIdAsync(int clientId);
    Task<IEnumerable<Order>> GetPendingOrdersAsync();
}
