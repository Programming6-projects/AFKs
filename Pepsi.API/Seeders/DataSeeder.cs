using Pepsi.Core.DTOs;
using Pepsi.Core.Interfaces.Services;
using Pepsi.Infrastructure.DataAccess;

namespace Pepsi.API.Seeders;

public class DataSeeder
{
    private readonly IVehicleService _vehicleService;
    private readonly IDataLoader<VehicleDto> _vehicleLoader;

    public DataSeeder(IVehicleService vehicleService, IDataLoader<VehicleDto> vehicleLoader)
    {
        _vehicleService = vehicleService;
        _vehicleLoader = vehicleLoader;
    }

    public async Task SeedVehiclesAsync(string jsonFilePath)
    {
        var existingVehicles = await _vehicleService.GetAllAsync().ConfigureAwait(false);
        foreach (var vehicle in existingVehicles)
        {
            await _vehicleService.DeleteAsync(vehicle.Id).ConfigureAwait(false);
        }

        var vehicles = await _vehicleLoader.LoadDataAsync(jsonFilePath).ConfigureAwait(false);
        foreach (var vehicle in vehicles)
        {
            await _vehicleService.AddAsync(vehicle).ConfigureAwait(false);
        }

        Console.WriteLine($"Loaded and added {vehicles.Count()} vehicles to the database.");
    }
}
