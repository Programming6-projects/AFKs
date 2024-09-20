using Pepsi.Core.Entities;

namespace Pepsi.Core.DTOs;

public class OrderDto : BaseDto
{
    public int ClientId { get; set; }
    public ClientDto? Client { get; set; }
    public int VehicleId { get; set; }
    public VehicleDto? Vehicle { get; set; }
    public IEnumerable<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    public decimal TotalVolume { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public OrderStatus Status { get; set; }
}
