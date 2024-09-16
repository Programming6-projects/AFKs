namespace Pepsi.Core.Entity;

public class Order(
    int id,
    int clientId,
    int vehicleId,
    decimal totalVolume,
    DateTime orderDate,
    DateTime deliveryDate,
    string status)
{
    public int Id { get; init; } = id;
    public int ClientId { get; init; } = clientId;
    public int VehicleId { get; init; } = vehicleId;
    public decimal TotalVolume { get; init; } = totalVolume;
    public DateTime OrderDate { get; init; } = orderDate;
    public DateTime DeliveryDate { get; init; } = deliveryDate;
    public string Status { get; init; } = status;
}
