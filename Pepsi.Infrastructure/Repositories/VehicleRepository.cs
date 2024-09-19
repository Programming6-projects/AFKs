using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure.DatabaseAccess;

namespace Pepsi.Infrastructure.Repositories;

public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(IDatabaseAccessor dbAccessor) : base(dbAccessor, "vehicles")
    {
    }

    public async Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync()
    {
        var sql = "SELECT * FROM Vehicles WHERE IsAvailable = @IsAvailable";
        return await DbAccessor.QueryAsync<Vehicle>(sql, new { IsAvailable = true }).ConfigureAwait(false);
    }
}
