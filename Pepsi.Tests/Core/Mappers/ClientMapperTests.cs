using Pepsi.Core.DTOs;
using Pepsi.Core.Entity;
using Pepsi.Core.Mappers;

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
        public void MapToDtoShouldMapClientToClientDto()
        {
            var client = new Client { Id = 1, Name = "Santiago", Region = "Cochabamba", Address = "123" };

            var clientDto = _mapper.MapToDto(client);

            Assert.Equal(client.Id, clientDto.Id);
            Assert.Equal(client.Name, clientDto.Name);
            Assert.Equal(client.Region, clientDto.Region);
            Assert.Equal(client.Address, clientDto.Address);
        }

        [Fact]
        public void MapToEntityShouldMapClientDtoToClient()
        {
            var clientDto = new ClientDto { Id = 1, Name = "Santiago", Region = "Cochabamba", Address = "123" };

            var client = _mapper.MapToEntity(clientDto);

            Assert.Equal(clientDto.Id, client.Id);
            Assert.Equal(clientDto.Name, client.Name);
            Assert.Equal(clientDto.Region, client.Region);
            Assert.Equal(clientDto.Address, client.Address);
        }

        [Fact]
        public void MapToDtoListShouldMapClientListToClientDtoList()
        {
            var clients = new List<Client>
            {
                new Client { Id = 1, Name = "Santiago", Region = "Cochabamba", Address = "123" },
                new Client { Id = 2, Name = "Maria", Region = "La Paz", Address = "456" }
            };

            var clientDtos = _mapper.MapToDtoList(clients);

            var enumerable = clientDtos as ClientDto[] ?? clientDtos.ToArray();
            Assert.Equal(clients.Count, enumerable.Length);
            Assert.Equal(clients[0].Id, enumerable.ElementAt(0).Id);
            Assert.Equal(clients[1].Id, enumerable.ElementAt(1).Id);
        }

        [Fact]
        public void MapToEntityListShouldMapClientDtoListToClientList()
        {
            var clientDtos = new List<ClientDto>
            {
                new ClientDto { Id = 1, Name = "Santiago", Region = "Cochabamba", Address = "123" },
                new ClientDto { Id = 2, Name = "Maria", Region = "La Paz", Address = "456" }
            };

            var clients = _mapper.MapToEntityList(clientDtos);

            var enumerable = clients as Client[] ?? clients.ToArray();
            Assert.Equal(clientDtos.Count, enumerable.Length);
            Assert.Equal(clientDtos[0].Id, enumerable.ElementAt(0).Id);
            Assert.Equal(clientDtos[1].Id, enumerable.ElementAt(1).Id);
        }
    }
}
