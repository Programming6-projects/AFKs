using System.Diagnostics;
using Pepsi.Core.Entities;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.Core.Validators;

public static class OrderValidator
{

    public static bool ValidateOrder(Order dto, IVehicleService vehicleService)
    {
        Debug.Assert(dto != null, nameof(dto) + " != null");
        if (!dto.Items.Any())
        {
            return false;
        }

        if (SelectVehicle(dto, vehicleService) == 0)
        {
            return false;
        }

        return true;
    }
    public static int SelectVehicle(Order dto, IVehicleService vehicleService)
    {
        Debug.Assert(vehicleService != null, nameof(vehicleService) + " != null");
        var available = vehicleService.GetAvailableVehiclesAsync();
        if (available.Result.Any())
        {
            foreach (var vehicleDto in available.Result)
            {
                if (dto != null && vehicleDto.NotUsedCapacity >= dto.TotalVolume)
                {
                    return vehicleDto.Id;
                }

            }
        }

        return 0;
    }
}
