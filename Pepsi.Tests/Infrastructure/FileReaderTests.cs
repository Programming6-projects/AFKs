using System.Text.Json;
using Pepsi.Core.Entity;
using Pepsi.Infrastructure.Utils;

namespace Pepsi.Tests.Infrastructure;

public class FileReaderTests
{
    //     private readonly string _testFilePath = Path.Combine(AppContext.BaseDirectory, "Data", "TestVehicles.json");
    //
    //     [Fact]
    //     public void ReadVehiclesFromJsonValidFileReturnsVehicleList()
    //     {
    //         var testVehicles = new List<Vehicle>
    //         {
    //             new Vehicle(1, "Trunk", 1000m),
    //             new Vehicle(2, "Van", 1000m)
    //         };
    //         File.WriteAllText(_testFilePath, JsonSerializer.Serialize(testVehicles));
    //
    //         var result = testVehicles;
    //
    //         Assert.NotNull(result);
    //         Assert.Equal(2, result.Count);
    //         Assert.Equal("Trunk", result[0].VehicleType);
    //         Assert.Equal("Van", result[1].VehicleType);
    //         File.Delete(_testFilePath);
    //     }
    //
    //     [Fact]
    //     public void ReadVehiclesFromJsonFileNotFoundThrowsFileNotFoundException()
    //     {
    //         if (File.Exists(_testFilePath))
    //         {
    //             File.Delete(_testFilePath);
    //         }
    // #pragma warning disable CS8974 // Converting method group to non-delegate type
    //         Assert.IsNotType<FileNotFoundException>(FileReader.ReadVehiclesFromJson);
    // #pragma warning restore CS8974 // Converting method group to non-delegate type
    //
    //     }
    //
    //     [Fact]
    //     public void ReadVehiclesFromJsonInvalidJsonReturnsNull()
    //     {
    //         File.WriteAllText(_testFilePath, "Invalid JSON content");
    //         var result = FileReader.ReadVehiclesFromJson();
    //         Assert.NotNull(result);
    //         File.Delete(_testFilePath);
    //     }
    //
    //
    //     [Fact]
    //     public void ReadVehiclesFromJsonValidFileReturnsVehicleLists()
    //     {
    //         var testVehicles = new List<Vehicle>
    //         {
    //             new Vehicle(1, "Trunk", 1000m),
    //             new Vehicle(2, "Van", 1000m)
    //         };
    //         File.WriteAllText(_testFilePath, JsonSerializer.Serialize(testVehicles));
    //
    //         var result = testVehicles;
    //
    //         Assert.NotNull(result);
    //         Assert.Equal(2, result.Count);
    //         Assert.Equal("Trunk", result[0].VehicleType);
    //         Assert.Equal("Van", result[1].VehicleType);
    //         File.Delete(_testFilePath);
    //     }
    //
    //     [Fact]
    //     public void ReadVehiclesFromJsonFileNotFoundThrowsFileNotFoundExceptions()
    //     {
    //         if (File.Exists(_testFilePath))
    //         {
    //             File.Delete(_testFilePath);
    //         }
    // #pragma warning disable CS8974 // Converting method group to non-delegate type
    //         Assert.IsNotType<FileNotFoundException>(FileReader.ReadVehiclesFromJson);
    // #pragma warning restore CS8974 // Converting method group to non-delegate type
    //
    //     }
    //
    //     [Fact]
    //     public void ReadVehiclesFromJsonInvalidJsonReturnsNulls()
    //     {
    //         File.WriteAllText(_testFilePath, "Invalid JSON content");
    //         var result = FileReader.ReadVehiclesFromJson();
    //         Assert.NotNull(result);
    //         File.Delete(_testFilePath);
    //     }
}
