namespace Pepsi.Core.Entity;

public class Vehicle : BaseEntity
{
    public string Type { get; set; } = string.Empty;
    public decimal Capacity { get; set; }
    public bool IsAvailable { get; set; } = true;
}
