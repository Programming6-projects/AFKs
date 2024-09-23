using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure.DatabaseAccess;

namespace Pepsi.Infrastructure.Repositories;

public class ClientRepository(IDatabaseAccessor dbAccessor)
    : GenericRepository<Client>(dbAccessor, "Clients"), IClientRepository
{
    public async Task<IEnumerable<Client>> GetClientsByRegionAsync(string region)
    {
        const string sql = "SELECT * FROM Clients WHERE Region = @Region";
        return await DbAccessor.QueryAsync<Client>(sql, new { Region = region }).ConfigureAwait(false);
    }
}
