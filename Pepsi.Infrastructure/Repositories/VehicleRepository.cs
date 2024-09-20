using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure.DatabaseAccess;

namespace Pepsi.Infrastructure.Repositories;

public class VehicleRepository(IDatabaseAccessor dbAccessor)
    : GenericRepository<Vehicle>(dbAccessor, "Vehicles"), IVehicleRepository
{
    public async Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync()
    {
        const string sql = "SELECT * FROM Vehicles WHERE IsAvailable = @IsAvailable";
        return await DbAccessor.QueryAsync<Vehicle>(sql, new { IsAvailable = true }).ConfigureAwait(false);
    }
}
