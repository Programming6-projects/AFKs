namespace Pepsi.Core.DTOs;

public class OrderItemDto : BaseDto
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public ProductDto? Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
