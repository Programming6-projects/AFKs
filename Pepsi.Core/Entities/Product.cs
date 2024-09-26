namespace Pepsi.Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public decimal Volume { get; init; }
    public ProductStock? Stock { get; set; }
}
