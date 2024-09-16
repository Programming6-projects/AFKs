namespace Pepsi.Core.Entity;

public class Vehicle(int id, string vehicleType, decimal capacity)
{
    public int Id { get; init; } = id;
    public string VehicleType { get; init; } = vehicleType;
    public decimal Capacity { get; init; } = capacity;
}
