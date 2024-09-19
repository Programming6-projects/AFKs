namespace Pepsi.Core.DTOs;

public class ProductStockDto : BaseDto
{
    public int QuantityOnHand { get; set; }
    public int QuantitySold { get; set; }
    public int QuantityReserved { get; set; }
    public int ProductId { get; set; }
}
