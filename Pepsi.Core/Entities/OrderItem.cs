namespace Pepsi.Core.Entity;

public class OrderItem : BaseEntity
{
    public int OrderId { get; init; }
    public Order? Order { get; set; }
    public int ProductId { get; init; }
    public Product? Product { get; set; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
}
