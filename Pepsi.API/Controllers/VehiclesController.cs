using Microsoft.AspNetCore.Mvc;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.API.Controllers.Concretes;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehiclesController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vehicles = await _vehicleService.GetAllAsync().ConfigureAwait(false);
        return Ok(vehicles);
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailable()
    {
        var availableVehicles = await _vehicleService.GetAvailableVehiclesAsync().ConfigureAwait(false);
        return Ok(availableVehicles);
    }

}
