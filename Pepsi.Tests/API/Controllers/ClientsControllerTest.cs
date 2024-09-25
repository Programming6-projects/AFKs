using Microsoft.AspNetCore.Mvc;
using Moq;
using Pepsi.API.Controllers;
using Pepsi.Core.DTOs;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Tests.API.Controllers;

public class ClientControllerTests
{
    private readonly Mock<IClientService> _mockClientService;
    private readonly ClientController _controller;

    public ClientControllerTests()
    {
        _mockClientService = new Mock<IClientService>();
        _controller = new ClientController(_mockClientService.Object);
    }

    [Fact]
    public async Task GetAllReturnsOkResultWithListOfClients()
    {
        // Arrange
        var clients = new List<ClientDto> { new ClientDto { Id = 1, Name = "Client1" } };
        _mockClientService.Setup(service => service.GetAllAsync()).ReturnsAsync(clients);

        // Act
        var result = await _controller.GetAll().ConfigureAwait(false);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<ClientDto>>(okResult.Value);
        Assert.Equal(clients, returnValue);
    }

    [Fact]
    public async Task GetByIdReturnsOkResultWithClient()
    {
        // Arrange
        var client = new ClientDto { Id = 1, Name = "Client1" };
        _mockClientService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync(client);

        // Act
        var result = await _controller.GetById(1).ConfigureAwait(false);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<ClientDto>(okResult.Value);
        Assert.Equal(client, returnValue);
    }

    [Fact]
    public async Task GetByIdReturnsNotFoundWhenClientIsNull()
    {
        // Arrange
        _mockClientService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync((ClientDto)null!);

        // Act
        var result = await _controller.GetById(1).ConfigureAwait(false);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task AddReturnsCreatedAtActionWithClientDto()
    {
        // Arrange
        var clientDto = new ClientDto { Id = 1, Name = "Client1" };
        _mockClientService.Setup(service => service.AddAsync(clientDto)).ReturnsAsync(1);

        // Act
        var result = await _controller.Add(clientDto).ConfigureAwait(false);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(nameof(_controller.GetById), createdAtActionResult.ActionName);
        Assert.Equal(clientDto, createdAtActionResult.Value);
    }

    [Fact]
    public async Task GetClientsByRegionReturnsOkResultWithListOfClients()
    {
        // Arrange
        var clients = new List<ClientDto> { new ClientDto { Id = 1, Name = "Client1" } };
        _mockClientService.Setup(service => service.GetClientsByRegionAsync("Region1")).ReturnsAsync(clients);

        // Act
        var result = await _controller.GetClientsByRegion("Region1").ConfigureAwait(false);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<ClientDto>>(okResult.Value);
        Assert.Equal(clients, returnValue);
    }
}
