using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Mappers;
using Xunit;

namespace Pepsi.Tests.Core.Mappers
{
    public class ClientMapperTests
    {
        private readonly ClientMapper _mapper;

        public ClientMapperTests()
        {
            _mapper = new ClientMapper();
        }

        [Fact]
        public void MapToDto_ShouldMapClientToClientDto()
        {
            var client = new Client { Id = 1, Name = "Santiago", Region = "Cochabamba", Address = "123" };

            var clientDto = _mapper.MapToDto(client);

            Assert.Equal(client.Id, clientDto.Id);
            Assert.Equal(client.Name, clientDto.Name);
            Assert.Equal(client.Region, clientDto.Region);
            Assert.Equal(client.Address, clientDto.Address);
        }

        [Fact]
        public void MapToEntity_ShouldMapClientDtoToClient()
        {
            var clientDto = new ClientDto { Id = 1, Name = "Santiago", Region = "Cochabamba", Address = "123" };

            var client = _mapper.MapToEntity(clientDto);

            Assert.Equal(clientDto.Id, client.Id);
            Assert.Equal(clientDto.Name, client.Name);
            Assert.Equal(clientDto.Region, client.Region);
            Assert.Equal(clientDto.Address, client.Address);
        }

        [Fact]
        public void MapToDtoList_ShouldMapClientListToClientDtoList()
        {
            var clients = new List<Client>
            {
                new Client { Id = 1, Name = "Santiago", Region = "Cochabamba", Address = "123" },
                new Client { Id = 2, Name = "Maria", Region = "La Paz", Address = "456" }
            };

            var clientDtos = _mapper.MapToDtoList(clients);

            Assert.Equal(clients.Count, clientDtos.Count());
            Assert.Equal(clients[0].Id, clientDtos.ElementAt(0).Id);
            Assert.Equal(clients[1].Id, clientDtos.ElementAt(1).Id);
        }

        [Fact]
        public void MapToEntityList_ShouldMapClientDtoListToClientList()
        {
            var clientDtos = new List<ClientDto>
            {
                new ClientDto { Id = 1, Name = "Santiago", Region = "Cochabamba", Address = "123" },
                new ClientDto { Id = 2, Name = "Maria", Region = "La Paz", Address = "456" }
            };

            var clients = _mapper.MapToEntityList(clientDtos);

            Assert.Equal(clientDtos.Count, clients.Count());
            Assert.Equal(clientDtos[0].Id, clients.ElementAt(0).Id);
            Assert.Equal(clientDtos[1].Id, clients.ElementAt(1).Id);
        }
    }
}
