using Microsoft.AspNetCore.Mvc;
using Moq;
using Pepsi.API.Controllers;
using Pepsi.Core.DTOs;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Tests.API.Controllers;

public class ProductControllerTests
{
    private readonly Mock<IProductService> _mockProductService;
    private readonly ProductController _controller;

    public ProductControllerTests()
    {
        _mockProductService = new Mock<IProductService>();
        _controller = new ProductController(_mockProductService.Object);
    }

    [Fact]
    public async Task GetByIdReturnsOkResultWithProduct()
    {
        // Arrange
        var productWithStockDto = new ProductWithStockDto { Id = 1, Name = "Product1" };
        _mockProductService.Setup(service => service.GetProductByIdWithStockAsync(1)).ReturnsAsync(productWithStockDto);

        // Act
        var result = await _controller.GetById(1).ConfigureAwait(false);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<ProductWithStockDto>(okResult.Value);
        Assert.Equal(productWithStockDto, returnValue);
    }

    [Fact]
    public async Task GetByIdReturnsNotFoundWhenProductIsNull()
    {
        // Arrange
        _mockProductService.Setup(service => service.GetProductByIdWithStockAsync(1)).ReturnsAsync((ProductWithStockDto)null!);

        // Act
        var result = await _controller.GetById(1).ConfigureAwait(false);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetProductsByNameReturnsOkResultWithListOfProducts()
    {
        // Arrange
        var productDtos = new List<ProductDto> { new() { Id = 1, Name = "Product1" } };
        _mockProductService.Setup(service => service.GetProductsByNameAsync("Product1")).ReturnsAsync(productDtos);

        // Act
        var result = await _controller.GetProductsByName("Product1").ConfigureAwait(false);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<ProductDto>>(okResult.Value);
        Assert.Equal(productDtos, returnValue);
    }

    [Fact]
    public async Task GetAllProductsReturnsOkResultWithListOfProducts()
    {
        // Arrange
        var productWithStockDtos = new List<ProductWithStockDto> { new() { Id = 1, Name = "Product1" } };
        _mockProductService.Setup(service => service.GetAllProductsWithStockAsync()).ReturnsAsync(productWithStockDtos);

        // Act
        var result = await _controller.GetAllProducts().ConfigureAwait(false);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<ProductWithStockDto>>(okResult.Value);
        Assert.Equal(productWithStockDtos, returnValue);
    }
}
