namespace Pepsi.Core.DTOs;

public class VehicleDto : BaseDto
{
    public string Type { get; init; } = string.Empty;
    public decimal Capacity { get; init; }
    public decimal UsedCapacity { get; set; }
    public decimal NotUsedCapacity { get; set; }
    public bool IsAvailable { get; init; }
}
