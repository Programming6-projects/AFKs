using Pepsi.Core.Entity;
using Pepsi.Infrastructure.Serialization;

namespace Pepsi.Tests.Infrastructure.Serialization;

public class JsonSerializerTests
{
    private readonly JsonSerializer _jsonSerializer;

    public JsonSerializerTests()
    {
        _jsonSerializer = new JsonSerializer();
    }

    [Fact]
    public void DeserializeShouldReturnCorrectObject()
    {
        var json = "{\"Id\":1,\"Name\":\"Client A\"}";
        var result = _jsonSerializer.Deserialize<Client>(json);
        Assert.NotNull(result);
        Assert.Equal(1, result.Id);
        Assert.Equal("Client A", result.Name);
    }

    [Fact]
    public void SerializeShouldReturnCorrectJsonString()
    {
        var client = new Client { Name = "Client A" };
        var result = _jsonSerializer.Serialize(client);
        Assert.Equal("{\"Name\":\"Client A\",\"Address\":\"\",\"Region\":\"\",\"Id\":0}", result);
    }
}
