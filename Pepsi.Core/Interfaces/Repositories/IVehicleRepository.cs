using Pepsi.Core.Entities;

namespace Pepsi.Core.Interfaces.Repositories;

public interface IVehicleRepository : IRepository<Vehicle>
{
    Task<IEnumerable<Vehicle>> GetAvailableVehiclesAsync();
}
