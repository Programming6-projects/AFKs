namespace Pepsi.Core.Entity;

public class Client : BaseEntity
{
    public string Name { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public string Region { get; init; } = string.Empty;
}
