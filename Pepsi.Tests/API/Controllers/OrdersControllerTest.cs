using Microsoft.AspNetCore.Mvc;
using Moq;
using Pepsi.API.Controllers;
using Pepsi.Core.DTOs;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Tests.API.Controllers;

public class OrderControllerTests
{
    private readonly Mock<IOrderService> _mockOrderService;
    private readonly OrderController _controller;

    public OrderControllerTests()
    {
        _mockOrderService = new Mock<IOrderService>();
        _controller = new OrderController(_mockOrderService.Object);
    }

    [Fact]
    public async Task GetAllReturnsOkResultWithListOfOrders()
    {
        // Arrange
        var orders = new List<OrderDto> { new() { Id = 1, ClientId = 1 } };
        _mockOrderService.Setup(service => service.GetAllAsync()).ReturnsAsync(orders);

        // Act
        var result = await _controller.GetAll().ConfigureAwait(false);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<OrderDto>>(okResult.Value);
        Assert.Equal(orders, returnValue);
    }

    [Fact]
    public async Task GetByIdReturnsOkResultWithOrder()
    {
        // Arrange
        var order = new OrderDto { Id = 1, ClientId = 1 };
        _mockOrderService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync(order);

        // Act
        var result = await _controller.GetById(1).ConfigureAwait(false);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<OrderDto>(okResult.Value);
        Assert.Equal(order, returnValue);
    }

    [Fact]
    public async Task GetByIdReturnsNotFoundWhenOrderIsNull()
    {
        // Arrange
        _mockOrderService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync((OrderDto)null!);

        // Act
        var result = await _controller.GetById(1).ConfigureAwait(false);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetOrdersByClientIdReturnsOkResultWithListOfOrders()
    {
        // Arrange
        var orders = new List<OrderDto> { new() { Id = 1, ClientId = 1 } };
        _mockOrderService.Setup(service => service.GetOrdersByClientIdAsync(1)).ReturnsAsync(orders);

        // Act
        var result = await _controller.GetOrdersByClientId(1).ConfigureAwait(false);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<OrderDto>>(okResult.Value);
        Assert.Equal(orders, returnValue);
    }

    [Fact]
    public async Task AddReturnsCreatedAtActionWithOrderDto()
    {
        // Arrange
        var orderDto = new OrderDto { Id = 1, ClientId = 1 };
        _mockOrderService.Setup(service => service.AddAsync(orderDto)).ReturnsAsync(1);

        // Act
        var result = await _controller.Add(orderDto).ConfigureAwait(false);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(nameof(_controller.GetById), createdAtActionResult.ActionName);
        Assert.Equal(orderDto, createdAtActionResult.Value);
    }
}
