namespace Pepsi.Core.DTOs;

public class ProductDto : BaseDto
{
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public decimal Volume { get; init; }
}
