namespace Pepsi.Core.Entities;

public class Order : BaseEntity
{
    public int ClientId { get; init; }
    public Client? Client { get; init; }
    public int VehicleId { get; set; }
    public Vehicle? Vehicle { get; init; }
    public IEnumerable<OrderItem> Items { get; init; } = new List<OrderItem>();
    public decimal TotalVolume { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; init; }
    public DateTime DeliveryDate { get; init; }
    public OrderStatus Status { get; set; }
}
