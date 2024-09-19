using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure.DatabaseAccess;

namespace Pepsi.Infrastructure.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(IDatabaseAccessor dbAccessor) : base(dbAccessor, "orders")
    {
    }

    public async Task<IEnumerable<Order>> GetOrdersByClientIdAsync(int clientId)
    {
        var sql = "SELECT * FROM Orders WHERE ClientId = @ClientId";
        return await DbAccessor.QueryAsync<Order>(sql, new { ClientId = clientId }).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Order>> GetPendingOrdersAsync()
    {
        var sql = "SELECT * FROM Orders WHERE Status = @Status";
        return await DbAccessor.QueryAsync<Order>(sql, new { Status = OrderStatus.Pending }).ConfigureAwait(false);
    }

    public override async Task<IEnumerable<Order>> GetAllAsync()
    {
        var sql = $"SELECT * FROM {TableName}";
        var orders = await DbAccessor.QueryAsync<Order>(sql).ConfigureAwait(false);

        foreach (var order in orders)
        {
            order.Status = Enum.Parse<OrderStatus>(order.Status.ToString());
        }
        return orders;
    }
}
