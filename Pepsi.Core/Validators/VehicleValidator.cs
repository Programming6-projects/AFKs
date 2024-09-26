using Pepsi.Core.DTOs;

namespace Pepsi.Core.Validators;

public static class VehicleValidator
{
    public static bool ValidateAvailability(VehicleDto vehicle)
    {
        if (vehicle.UsedCapacity == vehicle.Capacity)
        {
            return false;
        }

        return true;
    }
}
