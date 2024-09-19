using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;


public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _repository;
    private readonly IMapper<Vehicle, VehicleDto> _mapper;

    public VehicleService(IVehicleRepository repository, IMapper<Vehicle, VehicleDto> mapper) : base()
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<VehicleDto>> GetAllAsync()
    {
        var vehicles = await _repository.GetAllAsync().ConfigureAwait(false);
        return _mapper.MapToDtoList(vehicles);
    }

    public async Task<VehicleDto?> GetByIdAsync(int id)
    {
        var vehicle = await _repository.GetByIdAsync(id).ConfigureAwait(false);
        return vehicle != null ? _mapper.MapToDto(vehicle) : null;
    }

    public async Task<IEnumerable<VehicleDto>> GetAvailableVehiclesAsync()
    {
        var availableVehicles = await _repository.GetAvailableVehiclesAsync().ConfigureAwait(false);
        return _mapper.MapToDtoList(availableVehicles);
    }

    public async Task<int> AddAsync(VehicleDto entity)
    {
        var vehicle = _mapper.MapToEntity(entity);
        return await _repository.AddAsync(vehicle).ConfigureAwait(false);
    }

    public async Task UpdateAsync(VehicleDto entity)
    {
        var vehicle = _mapper.MapToEntity(entity);
        await _repository.UpdateAsync(vehicle).ConfigureAwait(false);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id).ConfigureAwait(false);
    }
}
