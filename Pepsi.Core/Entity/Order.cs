namespace Pepsi.Core.Entity;

public class Order
{
    public int id { get; init; }
    public int clientId { get; init; }
    public int vehicleId { get; init; }
    public decimal totalVolume { get; init; }
    public DateTime orderDate { get; init; }
    public DateTime deliveryDate { get; init; }
    public string status { get; init; }
}
