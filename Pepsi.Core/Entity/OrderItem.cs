namespace Pepsi.Core.Entity;

public class OrderItem(int id, int orderId, int productId, int quantity, decimal unitPrice)
{
    public int Id { get; init; } = id;
    public int OrderId { get; init; } = orderId;
    public int ProductId { get; init; } = productId;
    public int Quantity { get; init; } = quantity;
    public decimal UnitPrice { get; init; } = unitPrice;
}
