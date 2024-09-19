namespace Pepsi.Core.DTOs;

public class CompleteOrderDto : OrderDto
{
    public new ClientDto? Client { get; set; }
    public new VehicleDto? Vehicle { get; set; }
    public new IEnumerable<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
}
