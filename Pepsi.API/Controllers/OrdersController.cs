using Microsoft.AspNetCore.Mvc;
using Pepsi.Core.DTOs;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderService.GetAllAsync().ConfigureAwait(false);
        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await _orderService.GetByIdAsync(id).ConfigureAwait(false);
        if (order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpGet("client/{clientId}")]
    public async Task<IActionResult> GetOrdersByClientId(int clientId)
    {
        var orders = await _orderService.GetOrdersByClientIdAsync(clientId).ConfigureAwait(false);
        return Ok(orders);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] OrderDto orderDto)
    {
        var id = await _orderService.AddAsync(orderDto).ConfigureAwait(false);
        return CreatedAtAction(nameof(GetById), new { id }, orderDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] OrderDto orderDto)
    {
        if (id != orderDto.Id)
        {
            return BadRequest();
        }

        await _orderService.UpdateAsync(orderDto).ConfigureAwait(false);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _orderService.DeleteAsync(id).ConfigureAwait(false);
        return NoContent();
    }
}
