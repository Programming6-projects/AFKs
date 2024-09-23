namespace Pepsi.Core.Entities;

public class ProductStock : BaseEntity
{
    public int QuantityOnHand { get; init; }
    public int QuantitySold { get; init; }
    public int QuantityReserved { get; init; }
    public int ProductId { get; init; }
}
