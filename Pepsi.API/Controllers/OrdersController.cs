using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pepsi.Core.DTOs;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await orderService.GetAllAsync().ConfigureAwait(false);
        return Ok(orders);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await orderService.GetByIdAsync(id).ConfigureAwait(false);
        return order == null ? NotFound() : Ok(order);
    }

    [HttpGet("client/{clientId:int}")]
    public async Task<IActionResult> GetOrdersByClientId(int clientId)
    {
        var orders = await orderService.GetOrdersByClientIdAsync(clientId).ConfigureAwait(false);
        return Ok(orders);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] OrderDto orderDto)
    {
        var id = await orderService.AddAsync(orderDto).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetById), new { id }, orderDto);
    }
}
