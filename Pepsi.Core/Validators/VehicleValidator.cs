using System.Diagnostics;
using Pepsi.Core.DTOs;

namespace Pepsi.Core.Validators;

public static class VehicleValidator
{
    public static bool ValidateAvailability(VehicleDto vehicle)
    {
        Debug.Assert(vehicle != null, nameof(vehicle) + " != null");
        return vehicle.NotUsedCapacity == 0;
    }
}
