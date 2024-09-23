namespace Pepsi.Core.Entities;

public class Vehicle : BaseEntity
{
    public string Type { get; init; } = string.Empty;
    public decimal Capacity { get; init; }
    public bool IsAvailable { get; init; } = true;
}
