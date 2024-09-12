using System.Text.Json;
using Pepsi.Core.Entity;

namespace Pepsi.Infrastructure.Utils;

public static class FileReader
{
    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "Data", "Vehicles.json");

    public static List<Vehicle>? ReadVehiclesFromJson()
    {
        if (!File.Exists(_filePath))
        {
            throw new FileNotFoundException($"El archivo {_filePath} no se encontró.");
        }

        var jsonContent = File.ReadAllText(_filePath);
        var vehicles = JsonSerializer.Deserialize<List<Vehicle>>(jsonContent);

        return vehicles;
    }
}
