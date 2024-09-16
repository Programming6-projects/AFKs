namespace Pepsi.Core.Entity;

public class Client(int id, string name, string address, string region)
{
    public int Id { get; init; } = id;
    public string Name { get; init; } = name;
    public string Address { get; init; } = address;
    public string Region { get; init; } = region;
}
