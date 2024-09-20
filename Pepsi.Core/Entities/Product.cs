namespace Pepsi.Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Weight { get; set; }
    public ProductStock? Stock { get; set; }
}
