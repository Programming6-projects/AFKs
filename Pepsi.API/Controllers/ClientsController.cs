using Microsoft.AspNetCore.Mvc;
using Pepsi.Core.DTOs;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clients = await _clientService.GetAllAsync().ConfigureAwait(false);
        return Ok(clients);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var client = await _clientService.GetByIdAsync(id).ConfigureAwait(false);
        if (client == null)
        {
            return NotFound();
        }

        return Ok(client);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ClientDto clientDto)
    {
        var id = await _clientService.AddAsync(clientDto).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetById), new { id }, clientDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ClientDto clientDto)
    {
        if (id != clientDto.Id)
        {
            return BadRequest();
        }

        await _clientService.UpdateAsync(clientDto).ConfigureAwait(false);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _clientService.DeleteAsync(id).ConfigureAwait(false);
        return NoContent();
    }

    [HttpGet("region/{region}")]
    public async Task<IActionResult> GetClientsByRegion(string region)
    {
        var clients = await _clientService.GetClientsByRegionAsync(region).ConfigureAwait(false);
        return Ok(clients);
    }
}
