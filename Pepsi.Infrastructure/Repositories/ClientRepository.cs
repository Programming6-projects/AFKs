using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure.DatabaseAccess;

namespace Pepsi.Infrastructure.Repositories;

public class ClientRepository : GenericRepository<Client>, IClientRepository
{
    public ClientRepository(IDatabaseAccessor dbAccessor) : base(dbAccessor, "clients")
    {
    }

    public async Task<IEnumerable<Client>> GetClientsByRegionAsync(string region)
    {
        var sql = "SELECT * FROM Clients WHERE Region = @Region";
        return await DbAccessor.QueryAsync<Client>(sql, new { Region = region }).ConfigureAwait(false);
    }
}
