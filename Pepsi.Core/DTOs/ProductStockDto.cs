namespace Pepsi.Core.DTOs;

public class ProductStockDto : BaseDto
{
    public int QuantityOnHand { get; init; }
    public int QuantitySold { get; init; }
    public int QuantityReserved { get; init; }
    public int ProductId { get; init; }
}
