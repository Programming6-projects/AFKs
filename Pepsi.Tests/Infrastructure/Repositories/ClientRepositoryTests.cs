using Moq;
using Pepsi.Core.Entities;
using Pepsi.Infrastructure.DatabaseAccess;
using Pepsi.Infrastructure.Repositories;

namespace Pepsi.Tests.Infrastructure.Repositories;

public class ClientRepositoryTests
{
    private readonly Mock<IDatabaseAccessor> _databaseAccessorMock;
    private readonly ClientRepository _clientRepository;

    public ClientRepositoryTests()
    {
        _databaseAccessorMock = new Mock<IDatabaseAccessor>();
        _clientRepository = new ClientRepository(_databaseAccessorMock.Object);
    }

    [Fact]
    public async Task GetClientsByRegionAsyncShouldReturnCorrectClients()
    {
        var region = "West";
        var expectedClients = new List<Client> { new Client { Id = 1, Name = "Client A", Region = region } };
        _databaseAccessorMock.Setup(x => x.QueryAsync<Client>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(expectedClients);
        var result = await _clientRepository.GetClientsByRegionAsync(region).ConfigureAwait(false);
        Assert.NotNull(result);
        var collection = result as Client[] ?? result.ToArray();
        Assert.Single(collection);
        Assert.Equal(region, collection.First().Region);
    }

    [Fact]
    public async Task AddAsyncShouldReturnNewlyInsertedClientId()
    {
        var newClient = new Client { Name = "Client B", Address = "1234 Elm St", Region = "East" };
        _databaseAccessorMock.Setup(x => x.ExecuteScalarAsync<int>(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync(1);
        var result = await _clientRepository.AddAsync(newClient).ConfigureAwait(false);
        Assert.Equal(1, result);
    }
}

