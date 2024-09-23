using Pepsi.Core.DTOs;
using Pepsi.Core.Interfaces.Services;
using Pepsi.Infrastructure.DataAccess;

namespace Pepsi.API.Seeders;

public class DataSeeder(IVehicleService vehicleService, IDataLoader<VehicleDto> vehicleLoader)
{
    public async Task SeedVehiclesAsync(string jsonFilePath)
    {
        var currentVehicles = await vehicleService.GetAllAsync().ConfigureAwait(false);
        var vehicleDtos = currentVehicles.ToList();
        if (vehicleDtos.Count == 0)
        {
            var vehicles = await vehicleLoader.LoadDataAsync(jsonFilePath).ConfigureAwait(false);
            var enumerable = vehicles as VehicleDto[] ?? vehicles.ToArray();
            foreach (var vehicle in enumerable)
            {
                await vehicleService.AddAsync(vehicle).ConfigureAwait(false);
            }
            Console.WriteLine($"Loaded and added {enumerable.Length} vehicles to the database.");
        }
        Console.WriteLine($"Vehicles had been loaded before. Vehicle Count {vehicleDtos.Count} on the database");
    }
}
