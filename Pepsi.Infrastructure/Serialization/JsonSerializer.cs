using System.Text.Json;

namespace Pepsi.Infrastructure.Serialization;

public class JsonSerializer : ISerializer
{
    private readonly JsonSerializerOptions _options;

    public JsonSerializer()
    {
        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public T? Deserialize<T>(string data) where T : class
    {
        return System.Text.Json.JsonSerializer.Deserialize<T>(data, _options);
    }

    public string Serialize<T>(T data) where T : class
    {
        return System.Text.Json.JsonSerializer.Serialize(data, _options);
    }
}
