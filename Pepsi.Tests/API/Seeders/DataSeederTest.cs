using Moq;
using Pepsi.API.Seeders;
using Pepsi.Core.DTOs;
using Pepsi.Core.Interfaces.Services;
using Pepsi.Infrastructure.DataAccess;

namespace Pepsi.Tests.API.Seeders;

public class DataSeederTests
{
    private readonly Mock<IVehicleService> _mockVehicleService;
    private readonly Mock<IDataLoader<VehicleDto>> _mockVehicleLoader;
    private readonly DataSeeder _dataSeeder;

    public DataSeederTests()
    {
        _mockVehicleService = new Mock<IVehicleService>();
        _mockVehicleLoader = new Mock<IDataLoader<VehicleDto>>();
        _dataSeeder = new DataSeeder(_mockVehicleService.Object, _mockVehicleLoader.Object);
    }

    [Fact]
    public async Task SeedVehiclesAsyncShouldLoadAndAddVehiclesWhenNoVehiclesExist()
    {
        // Arrange
        _mockVehicleService.Setup(service => service.GetAllAsync()).ReturnsAsync(new List<VehicleDto>());
        var vehicles = new List<VehicleDto> { new() { Id = 1, Type = "Type1", Capacity = 100, IsAvailable = true } };
        _mockVehicleLoader.Setup(loader => loader.LoadDataAsync(It.IsAny<string>())).ReturnsAsync(vehicles);

        // Act
        await _dataSeeder.SeedVehiclesAsync("path/to/json").ConfigureAwait(false);

        // Assert
        _mockVehicleService.Verify(service => service.AddAsync(It.IsAny<VehicleDto>()), Times.Once);
    }

    [Fact]
    public async Task SeedVehiclesAsyncShouldNotLoadVehiclesWhenVehiclesExist()
    {
        // Arrange
        var existingVehicles = new List<VehicleDto> { new() { Id = 1, Type = "Type1", Capacity = 100, IsAvailable = true } };
        _mockVehicleService.Setup(service => service.GetAllAsync()).ReturnsAsync(existingVehicles);

        // Act
        await _dataSeeder.SeedVehiclesAsync("path/to/json").ConfigureAwait(false);

        // Assert
        _mockVehicleLoader.Verify(loader => loader.LoadDataAsync(It.IsAny<string>()), Times.Never);
        _mockVehicleService.Verify(service => service.AddAsync(It.IsAny<VehicleDto>()), Times.Never);
    }
}
