namespace Pepsi.Core.Entity;

public class Order : BaseEntity
{
    public int ClientId { get; init; }
    public Client? Client { get; set; }
    public int VehicleId { get; init; }
    public Vehicle? Vehicle { get; set; }
    public IEnumerable<OrderItem> Items { get; set; } = new List<OrderItem>();
    public decimal TotalVolume { get; init; }
    public DateTime OrderDate { get; init; }
    public DateTime DeliveryDate { get; init; }
    public OrderStatus Status { get; set; }
}
