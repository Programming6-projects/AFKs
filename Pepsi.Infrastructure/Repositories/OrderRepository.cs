using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure.DatabaseAccess;

namespace Pepsi.Infrastructure.Repositories;

public class OrderRepository(IDatabaseAccessor dbAccessor)
    : GenericRepository<Order>(dbAccessor, "Orders"), IOrderRepository
{
    public async Task<IEnumerable<Order>> GetOrdersByClientIdAsync(int clientId)
    {
        const string sql = "SELECT * FROM Orders WHERE ClientId = @ClientId";
        return await DbAccessor.QueryAsync<Order>(sql, new { ClientId = clientId }).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Order>> GetPendingOrdersAsync()
    {
        const string sql = "SELECT * FROM Orders WHERE Status = @Status";
        return await DbAccessor.QueryAsync<Order>(sql, new { Status = OrderStatus.Pending }).ConfigureAwait(false);
    }

    public override async Task<IEnumerable<Order>> GetAllAsync()
    {
        var sql = $"SELECT * FROM {TableName}";
        var orders = await DbAccessor.QueryAsync<Order>(sql).ConfigureAwait(false);

        IEnumerable<Order> allAsync = orders.ToList();
        foreach (var order in allAsync)
        {
            order.Status = Enum.Parse<OrderStatus>(order.Status.ToString());
        }
        return allAsync;
    }
}
