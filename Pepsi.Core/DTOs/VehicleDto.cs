namespace Pepsi.Core.DTOs;

public class VehicleDto : BaseDto
{
    public string Type { get; set; } = string.Empty;
    public decimal Capacity { get; set; }
    public bool IsAvailable { get; set; }
}
