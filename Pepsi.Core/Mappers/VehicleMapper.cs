using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Mappers;

namespace Pepsi.Core.Mappers;

public class VehicleMapper : IMapper<Vehicle, VehicleDto>
{
    public VehicleDto MapToDto(Vehicle entity) => new VehicleDto
    {
        Id = entity.Id,
        Type = entity.Type,
        Capacity = entity.Capacity,
        IsAvailable = entity.IsAvailable
    };

    public Vehicle MapToEntity(VehicleDto dto) => new Vehicle
    {
        Id = dto.Id,
        Type = dto.Type,
        Capacity = dto.Capacity,
        IsAvailable = dto.IsAvailable
    };

    public IEnumerable<VehicleDto> MapToDtoList(IEnumerable<Vehicle> entities) =>
        entities.Select(MapToDto);

    public IEnumerable<Vehicle> MapToEntityList(IEnumerable<VehicleDto> dtos) =>
        dtos.Select(MapToEntity);
}
