using Pepsi.Core.Entities;

namespace Pepsi.Core.DTOs;

public class OrderDto : BaseDto
{
    public int ClientId { get; init; }
    public int VehicleId { get; init; }
    public IEnumerable<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    public DateTime DeliveryDate { get; init; }
}
