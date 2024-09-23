namespace Pepsi.Core.Entities;

public class OrderItem : BaseEntity
{
    public int OrderId { get; init; }
    public Order? Order { get; set; }
    public int ProductId { get; init; }
    public Product? Product { get; init; }
    public int Quantity { get; init; }
    public decimal UnitPrice { get; init; }
}
