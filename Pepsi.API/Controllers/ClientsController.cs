using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pepsi.Core.DTOs;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController(IClientService clientService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clients = await clientService.GetAllAsync().ConfigureAwait(false);
        return Ok(clients);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var client = await clientService.GetByIdAsync(id).ConfigureAwait(false);
        return client == null ? NotFound() : Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ClientDto clientDto)
    {
        var id = await clientService.AddAsync(clientDto).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetById), new { id }, clientDto);
    }

    [HttpGet("region/{region}")]
    public async Task<IActionResult> GetClientsByRegion(string region)
    {
        var clients = await clientService.GetClientsByRegionAsync(region).ConfigureAwait(false);
        return Ok(clients);
    }
}
