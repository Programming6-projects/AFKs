namespace Pepsi.Core.DTOs;

public class ProductWithStockDto : ProductDto
{
    public ProductStockDto? Stock { get; set; }
}
