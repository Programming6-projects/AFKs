using Moq;
using Pepsi.Core.Entity;
using Pepsi.Infrastructure.DatabaseAccess;
using Pepsi.Infrastructure.Repositories;

namespace Pepsi.Tests.Infrastructure.Repositories;

public class OrderItemRepositoryTests
{
    private readonly Mock<IDatabaseAccessor> _databaseAccessorMock;
    private readonly OrderItemRepository _orderItemRepository;

    public OrderItemRepositoryTests()
    {
        _databaseAccessorMock = new Mock<IDatabaseAccessor>();
        _orderItemRepository = new OrderItemRepository(_databaseAccessorMock.Object);
    }

    [Fact]
    public async Task GetOrderItemsByOrderIdAsyncShouldReturnCorrectOrderItems()
    {
        var orderId = 1;
        var expectedItems = new List<OrderItem> { new OrderItem { Id = 1, OrderId = orderId, ProductId = 100 } };
        _databaseAccessorMock.Setup(x => x.QueryAsync<OrderItem>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(expectedItems);
        var result = await _orderItemRepository.GetOrderItemsByOrderIdAsync(orderId).ConfigureAwait(false);
        Assert.NotNull(result);
        var orderItems = result as OrderItem[] ?? result.ToArray();
        Assert.Single(orderItems);
        Assert.Equal(orderId, orderItems.First().OrderId);
    }

    [Fact]
    public async Task AddAsyncShouldInsertOrderItemAndReturnId()
    {
        var newOrderItem = new OrderItem { ProductId = 100, OrderId = 1, Quantity = 2 };
        _databaseAccessorMock.Setup(x => x.ExecuteScalarAsync<int>(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync(1);

        var result = await _orderItemRepository.AddAsync(newOrderItem).ConfigureAwait(false);
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task DeleteAsyncShouldDeleteOrderItem()
    {
        var orderItemId = 1;
        _databaseAccessorMock.Setup(x => x.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync(1);
        await _orderItemRepository.DeleteAsync(orderItemId).ConfigureAwait(false);
        _databaseAccessorMock.Verify(x => x.ExecuteAsync(It.Is<string>(s => s.Contains("DELETE")), It.IsAny<object>()), Times.Once);
    }
}
