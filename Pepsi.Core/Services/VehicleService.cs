using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;


public class VehicleService(IVehicleRepository repository, IMapper<Vehicle, VehicleDto> mapper)
    : IVehicleService
{
    public async Task<IEnumerable<VehicleDto>> GetAllAsync()
    {
        var vehicles = await repository.GetAllAsync().ConfigureAwait(false);
        return mapper.MapToDtoList(vehicles);
    }

    public async Task<VehicleDto?> GetByIdAsync(int id)
    {
        var vehicle = await repository.GetByIdAsync(id).ConfigureAwait(false);
        return vehicle != null ? mapper.MapToDto(vehicle) : null;
    }

    public async Task<IEnumerable<VehicleDto>> GetAvailableVehiclesAsync()
    {
        var availableVehicles = await repository.GetAvailableVehiclesAsync().ConfigureAwait(false);
        return mapper.MapToDtoList(availableVehicles);
    }

    public async Task<int> AddAsync(VehicleDto dto)
    {
        var vehicle = mapper.MapToEntity(dto);
        return await repository.AddAsync(vehicle).ConfigureAwait(false);
    }

    public async Task UpdateAsync(VehicleDto dto)
    {
        var vehicle = mapper.MapToEntity(dto);
        await repository.UpdateAsync(vehicle).ConfigureAwait(false);
    }

    public async Task DeleteAsync(int id)
    {
        await repository.DeleteAsync(id).ConfigureAwait(false);
    }
}
