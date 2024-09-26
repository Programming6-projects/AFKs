using System.Diagnostics;
using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;

namespace Pepsi.Core.Mappers;

public class VehicleMapper : IMapper<Vehicle, VehicleDto>
{
    public VehicleDto MapToDto(Vehicle entity)
    {
        Debug.Assert(entity != null, nameof(entity) + " != null");
        return new VehicleDto
        {
            Id = entity.Id,
            Type = entity.Type,
            Capacity = entity.Capacity,
            UsedCapacity = entity.UsedCapacity,
            NotUsedCapacity = entity.NotUsedCapacity,
            IsAvailable = entity.IsAvailable
        };
    }

    public Vehicle MapToEntity(VehicleDto dto)
    {
        Debug.Assert(dto != null, nameof(dto) + " != null");
        return new Vehicle { Id = dto.Id, Type = dto.Type, Capacity = dto.Capacity, NotUsedCapacity = dto.NotUsedCapacity, UsedCapacity = dto.UsedCapacity, IsAvailable = dto.IsAvailable };
    }

    public Task<Vehicle> MapFromCreateToEntity(VehicleDto dto)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<VehicleDto> MapToDtoList(IEnumerable<Vehicle> entities) =>
        entities.Select(MapToDto);

    public IEnumerable<Vehicle> MapToEntityList(IEnumerable<VehicleDto> dtos) =>
        dtos.Select(MapToEntity);
}
