using Pepsi.Core.Entities;

namespace Pepsi.Core.DTOs;

public class CompleteOrderItemDto : OrderItemDto
{

    public int OrderId { get; init; }
    public int ProductId { get; init; }
    public ProductDto? Product { get; init; }
    public int Quantity { get; init; }
}
