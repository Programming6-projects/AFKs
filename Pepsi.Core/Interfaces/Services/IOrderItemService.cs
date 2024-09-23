using Pepsi.Core.DTOs;

namespace Pepsi.Core.Interfaces.Services;


public interface IOrderItemService : IReadOnlyService<OrderItemDto>, ITransactionalService<OrderItemDto>
{
    Task<IEnumerable<OrderItemDto>> GetOrderItemsByOrderIdAsync(int orderDtoId);
}
