namespace Pepsi.Core.DTOs;

public class OrderItemDto : BaseDto
{
    public int OrderId { get; set; }
    public int ProductId { get; init; }
    public int Quantity { get; init; }
}
