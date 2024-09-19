using Pepsi.Core.Entity;

namespace Pepsi.Core.Interfaces.Repositories;

public interface IClientRepository : IRepository<Client>
{
    Task<IEnumerable<Client>> GetClientsByRegionAsync(string region);
}
