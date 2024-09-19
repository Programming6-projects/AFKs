using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Interfaces.Mappers;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Services;

public class ClientService(IClientRepository clientRepository, IMapper<Client, ClientDto> mapper)
    : IClientService
{
    public async Task<IEnumerable<ClientDto>> GetAllAsync()
    {
        var clients = await clientRepository.GetAllAsync().ConfigureAwait(false);
        return mapper.MapToDtoList(clients);
    }

    public async Task<ClientDto?> GetByIdAsync(int id)
    {
        var client = await clientRepository.GetByIdAsync(id).ConfigureAwait(false);
        if (client != null)
        {
            return mapper.MapToDto(client);
        }

        return null;
    }

    public async Task<int> AddAsync(ClientDto entity)
    {
        var client = mapper.MapToEntity(entity);
        return await clientRepository.AddAsync(client).ConfigureAwait(false);
    }

    public async Task UpdateAsync(ClientDto entity)
    {
        var client = mapper.MapToEntity(entity);
        await clientRepository.UpdateAsync(client).ConfigureAwait(false);
    }

    public async Task DeleteAsync(int id)
    {
        await clientRepository.DeleteAsync(id).ConfigureAwait(false);
    }

    public async Task<IEnumerable<ClientDto>> GetClientsByRegionAsync(string region)
    {
        var clients = await clientRepository.GetClientsByRegionAsync(region).ConfigureAwait(false);
        return mapper.MapToDtoList(clients);
    }
}
