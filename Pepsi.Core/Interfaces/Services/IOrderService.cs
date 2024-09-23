using Pepsi.Core.DTOs;

namespace Pepsi.Core.Interfaces.Services;


public interface IOrderService : IReadOnlyService<OrderDto>, ITransactionalService<OrderDto>
{
    Task<IEnumerable<OrderDto>> GetOrdersByClientIdAsync(int clientId);
}
