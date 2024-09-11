namespace Pepsi.Core.Entity;

public class Product
{
    public int id { get; init; }
    public string name { get; init; }
    public int quantityOnHand { get; init; }
    public int quantitySold { get; init; }
    public int quantityReserved { get; init; }
    public decimal price { get; init; }
    public decimal volume { get; init; }
}
