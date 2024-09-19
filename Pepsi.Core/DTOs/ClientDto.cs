namespace Pepsi.Core.DTOs;

public class ClientDto : BaseDto
{
    public string Name { get; init; } = string.Empty;
    public string Address { get; init; } = string.Empty;
    public string Region { get; init; } = string.Empty;
}
