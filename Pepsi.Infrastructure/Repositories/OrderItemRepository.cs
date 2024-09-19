using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure.DatabaseAccess;

namespace Pepsi.Infrastructure.Repositories;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(IDatabaseAccessor dbAccessor) : base(dbAccessor, "OrderItems")
    {
    }

    public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
    {
        var sql = "SELECT * FROM OrderItems WHERE OrderId = @OrderId";
        return await DbAccessor.QueryAsync<OrderItem>(sql, new { OrderId = orderId }).ConfigureAwait(false);
    }
}
