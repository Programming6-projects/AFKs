namespace Pepsi.Core.Entity;

public class Product(
    int id,
    string name,
    int quantityOnHand,
    int quantitySold,
    int quantityReserved,
    decimal price,
    decimal volume)
{
    public int Id { get; init; } = id;
    public string Name { get; init; } = name;
    public int QuantityOnHand { get; init; } = quantityOnHand;
    public int QuantitySold { get; init; } = quantitySold;
    public int QuantityReserved { get; init; } = quantityReserved;
    public decimal Price { get; init; } = price;
    public decimal Volume { get; init; } = volume;
}
