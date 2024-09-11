namespace Pepsi.Core.Entity;

public class OrderItem
{
    public int id { get; init; }
    public int orderId { get; init; }
    public int productId { get; init; }
    public int quantity { get; init; }
    public decimal unitPrice { get; init; }
}
