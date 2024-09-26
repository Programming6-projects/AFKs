using Pepsi.Core.DTOs;

namespace Pepsi.Core.Entities;

public class OrderItem : BaseEntity
{
    public int OrderId { get; init; }
    public Order? Order { get; set; }
    public int ProductId { get; init; }
    public ProductWithStockDto? Product { get; set; }
    public int Quantity { get; init; }
}
