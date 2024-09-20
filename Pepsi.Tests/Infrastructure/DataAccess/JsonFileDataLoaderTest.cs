using Moq;
using Pepsi.Core.Entity;
using Pepsi.Infrastructure.DataAccess;
using Pepsi.Infrastructure.FileAccess;
using Pepsi.Infrastructure.Serialization;

namespace Pepsi.Tests.Infrastructure.DataAccess;

public class JsonFileDataLoaderTests
{
    private readonly Mock<IFileReader> _fileReaderMock;
    private readonly Mock<ISerializer> _serializerMock;
    private readonly JsonFileDataLoader<Client> _dataLoader;

    public JsonFileDataLoaderTests()
    {
        _fileReaderMock = new Mock<IFileReader>();
        _serializerMock = new Mock<ISerializer>();
        _dataLoader = new JsonFileDataLoader<Client>(_fileReaderMock.Object, _serializerMock.Object);
    }

    [Fact]
    public async Task LoadDataAsyncShouldReturnDeserializedDataWhenFileExists()
    {
        var jsonData = "[{\"Id\":1,\"Name\":\"Client A\",\"Address\":\"Address A\"}]";
        _fileReaderMock.Setup(x => x.ReadFileAsync(It.IsAny<string>())).ReturnsAsync(jsonData);
        _serializerMock.Setup(x => x.Deserialize<List<Client>>(jsonData)).Returns(new List<Client> { new Client { Id = 1, Name = "Client A" } });
        var result = await _dataLoader.LoadDataAsync("path/to/json").ConfigureAwait(false);
        Assert.NotNull(result);
        var collection = result as Client[] ?? result.ToArray();
        Assert.Single(collection);
        Assert.Equal(1, collection.First().Id);
        Assert.Equal("Client A", collection.First().Name);
    }

    [Fact]
    public async Task LoadDataAsyncShouldReturnEmptyListWhenFileIsEmpty()
    {
        _fileReaderMock.Setup(x => x.ReadFileAsync(It.IsAny<string>())).ReturnsAsync(string.Empty);
        _serializerMock.Setup(x => x.Deserialize<List<Client>>(string.Empty)).Returns(new List<Client>());
        var result = await _dataLoader.LoadDataAsync("path/to/json").ConfigureAwait(false);
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public async Task LoadDataAsyncShouldThrowExceptionWhenFileNotFound()
    {
        _fileReaderMock.Setup(x => x.ReadFileAsync(It.IsAny<string>())).ThrowsAsync(new FileNotFoundException());
        await Assert.ThrowsAsync<FileNotFoundException>(() => _dataLoader.LoadDataAsync("invalid/path")).ConfigureAwait(false);
    }
}

