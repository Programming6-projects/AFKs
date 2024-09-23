namespace Pepsi.Infrastructure.Serialization;

public interface ISerializer
{
    T? Deserialize<T>(string data) where T : class;
    string Serialize<T>(T data) where T : class;
}
