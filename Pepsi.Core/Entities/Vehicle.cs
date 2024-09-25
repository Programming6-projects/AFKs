namespace Pepsi.Core.Entities;

public class Vehicle : BaseEntity
{
    public string Type { get; init; } = string.Empty;
    public decimal Capacity { get; init; }
    public decimal UsedCapacity { get; set; }
    public decimal NotUsedCapacity { get; set; }
    public bool IsAvailable { get; init; } = true;
}
