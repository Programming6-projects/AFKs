using Moq;
using Pepsi.Core.Entities;
using Pepsi.Infrastructure.DatabaseAccess;
using Pepsi.Infrastructure.Repositories;

namespace Pepsi.Tests.Infrastructure.Repositories;

public class VehicleRepositoryTests
{
    private readonly Mock<IDatabaseAccessor> _databaseAccessorMock;
    private readonly VehicleRepository _vehicleRepository;

    public VehicleRepositoryTests()
    {
        _databaseAccessorMock = new Mock<IDatabaseAccessor>();
        _vehicleRepository = new VehicleRepository(_databaseAccessorMock.Object);
    }

    [Fact]
    public async Task GetAvailableVehiclesAsyncShouldReturnAvailableVehicles()
    {
        var expectedVehicles = new List<Vehicle> { new Vehicle { Id = 1, IsAvailable = true } };
        _databaseAccessorMock.Setup(x => x.QueryAsync<Vehicle>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(expectedVehicles);
        var result = await _vehicleRepository.GetAvailableVehiclesAsync().ConfigureAwait(false);
        Assert.NotNull(result);
        var collection = result as Vehicle[] ?? result.ToArray();
        Assert.Single(collection);
        Assert.True(collection.First().IsAvailable);
    }

    [Fact]
    public async Task AddAsyncShouldInsertVehicleAndReturnId()
    {
        var newVehicle = new Vehicle { IsAvailable = true, Type = "van", Capacity = 7000};
        _databaseAccessorMock.Setup(x => x.ExecuteScalarAsync<int>(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync(1);
        var result = await _vehicleRepository.AddAsync(newVehicle).ConfigureAwait(false);
        Assert.Equal(1, result);
    }
}
