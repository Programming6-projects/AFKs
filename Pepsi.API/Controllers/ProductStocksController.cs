using Microsoft.AspNetCore.Mvc;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductStocksController : ControllerBase
{
    private readonly IProductStockRepository _orderRepository;

    public ProductStocksController(IProductStockRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderRepository.GetAllAsync().ConfigureAwait(false);
        return Ok(orders);
    }
}
