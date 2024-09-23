using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure.DatabaseAccess;

namespace Pepsi.Infrastructure.Repositories;

public class OrderItemRepository(IDatabaseAccessor dbAccessor)
    : GenericRepository<OrderItem>(dbAccessor, "OrderItems"), IOrderItemRepository
{
    public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
    {
        const string sql = "SELECT * FROM OrderItems WHERE OrderId = @OrderId";
        return await DbAccessor.QueryAsync<OrderItem>(sql, new { OrderId = orderId }).ConfigureAwait(false);
    }
}
