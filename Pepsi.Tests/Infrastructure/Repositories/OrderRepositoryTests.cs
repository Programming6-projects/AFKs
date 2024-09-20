using Moq;
using Pepsi.Core.Entities;
using Pepsi.Infrastructure.DatabaseAccess;
using Pepsi.Infrastructure.Repositories;

namespace Pepsi.Tests.Infrastructure.Repositories;

public class OrderRepositoryTests
{
    private readonly Mock<IDatabaseAccessor> _databaseAccessorMock;
    private readonly OrderRepository _orderRepository;

    public OrderRepositoryTests()
    {
        _databaseAccessorMock = new Mock<IDatabaseAccessor>();
        _orderRepository = new OrderRepository(_databaseAccessorMock.Object);
    }

    [Fact]
    public async Task GetOrdersByClientIdAsyncShouldReturnCorrectOrders()
    {
        var clientId = 1;
        var expectedOrders = new List<Order> { new Order { Id = 1, ClientId = clientId, Status = OrderStatus.Pending } };
        _databaseAccessorMock.Setup(x => x.QueryAsync<Order>(It.IsAny<string>(), It.IsAny<object>()))
                             .ReturnsAsync(expectedOrders);
        var result = await _orderRepository.GetOrdersByClientIdAsync(clientId).ConfigureAwait(false);
        Assert.NotNull(result);
        var collection = result as Order[] ?? result.ToArray();
        Assert.Single(collection);
        Assert.Equal(clientId, collection.First().ClientId);
    }

    [Fact]
    public async Task GetPendingOrdersAsyncShouldReturnPendingOrders()
    {
        var expectedOrders = new List<Order> { new Order { Id = 1, Status = OrderStatus.Pending } };
        _databaseAccessorMock.Setup(x => x.QueryAsync<Order>(It.IsAny<string>(), It.IsAny<object>()))
                             .ReturnsAsync(expectedOrders);
        var result = await _orderRepository.GetPendingOrdersAsync().ConfigureAwait(false);
        Assert.NotNull(result);
        var collection = result as Order[] ?? result.ToArray();
        Assert.Single(collection);
        Assert.Equal(OrderStatus.Pending, collection.First().Status);
    }

    [Fact]
    public async Task AddAsyncShouldInsertOrderAndReturnId()
    {
        var newOrder = new Order { ClientId = 1, Status = OrderStatus.Pending };
        _databaseAccessorMock.Setup(x => x.ExecuteScalarAsync<int>(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync(1);

        var result = await _orderRepository.AddAsync(newOrder).ConfigureAwait(false);
        Assert.Equal(1, result);
    }
}
