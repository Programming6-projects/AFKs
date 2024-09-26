using Pepsi.Core.Entities;

namespace Pepsi.Core.DTOs;

public class CompleteOrderItemDto : OrderItemDto
{

    public new int OrderId { get; init; }
    public new int ProductId { get; init; }
    public Product? Product { get; init; }
    public new int Quantity { get; init; }
}
