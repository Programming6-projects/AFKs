using System.Diagnostics;
using Pepsi.Core.DTOs;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Mappers;

namespace Pepsi.Core.Mappers;

public class ClientMapper : IMapper<Client, ClientDto>
{
    public ClientDto MapToDto(Client entity)
    {
        Debug.Assert(entity != null, nameof(entity) + " != null");
        return new ClientDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            Region = entity.Region,
            Address = entity.Address
        };
    }

    public Client MapToEntity(ClientDto dto)
    {
        Debug.Assert(dto != null, nameof(dto) + " != null");
        return new Client() { Id = dto.Id, Name = dto.Name, Region = dto.Region, Address = dto.Address };
    }

    public Task<Client> MapFromCreateToEntity(ClientDto dto)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ClientDto> MapToDtoList(IEnumerable<Client> entities)
    {
        return entities.Select(MapToDto).ToList();
    }

    public IEnumerable<Client> MapToEntityList(IEnumerable<ClientDto> dtos)
    {
        return dtos.Select(MapToEntity).ToList();
    }
}
