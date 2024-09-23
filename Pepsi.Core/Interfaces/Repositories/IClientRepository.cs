using Pepsi.Core.Entities;

namespace Pepsi.Core.Interfaces.Repositories;

public interface IClientRepository : IRepository<Client>
{
    Task<IEnumerable<Client>> GetClientsByRegionAsync(string region);
}
