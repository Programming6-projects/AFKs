namespace Pepsi.Core.DTOs;

public class ProductDto : BaseDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Weight { get; set; }
}
