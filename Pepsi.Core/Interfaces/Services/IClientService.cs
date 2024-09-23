using Pepsi.Core.DTOs;

namespace Pepsi.Core.Interfaces.Services;

public interface IClientService : IReadOnlyService<ClientDto>, ITransactionalService<ClientDto>
{
    Task<IEnumerable<ClientDto>> GetClientsByRegionAsync(string region);
}
