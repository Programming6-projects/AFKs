using Pepsi.Core.Entities;

namespace Pepsi.Core.DTOs;

public class CompleteOrderDto : OrderDto
{
    public new int ClientId { get; init; }
    public ClientDto? Client { get; set; }
    public new int VehicleId { get; init; }
    public VehicleDto? Vehicle { get; set; }
    public new IEnumerable<CompleteOrderItemDto> Items { get; set; } = new List<CompleteOrderItemDto>();
    public decimal TotalVolume { get; init; }
    public DateTime OrderDate { get; init; }
    public new DateTime DeliveryDate { get; init; }
    public OrderStatus Status { get; init; }
}
