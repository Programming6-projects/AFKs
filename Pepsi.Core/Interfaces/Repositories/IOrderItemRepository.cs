using Pepsi.Core.Entities;

namespace Pepsi.Core.Interfaces.Repositories;

public interface IOrderItemRepository : IRepository<OrderItem>
{
    Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
}
