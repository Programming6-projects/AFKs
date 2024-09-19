using Pepsi.Core.DTOs;

namespace Pepsi.Core.Interfaces.Services;

public interface IVehicleService : IReadOnlyService<VehicleDto>, ITransactionalService<VehicleDto>
{
    Task<IEnumerable<VehicleDto>> GetAvailableVehiclesAsync();
}
