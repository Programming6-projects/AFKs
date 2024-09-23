using Pepsi.Core.Entities;

namespace Pepsi.Core.DTOs;

public class OrderDto : BaseDto
{
    public int ClientId { get; init; }
    public ClientDto? Client { get; set; }
    public int VehicleId { get; init; }
    public VehicleDto? Vehicle { get; set; }
    public IEnumerable<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    public decimal TotalVolume { get; init; }
    public DateTime OrderDate { get; init; }
    public DateTime DeliveryDate { get; init; }
    public OrderStatus Status { get; init; }
}
