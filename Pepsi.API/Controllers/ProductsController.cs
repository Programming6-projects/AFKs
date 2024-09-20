using Microsoft.AspNetCore.Mvc;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var productDto = await productService.GetProductByIdWithStockAsync(id).ConfigureAwait(false);
        return productDto == null ? NotFound() : Ok(productDto);
    }

    [HttpGet("search")]
    public async Task<IActionResult> GetProductsByName(string name)
    {
        var productDtos = await productService.GetProductsByNameAsync(name).ConfigureAwait(false);
        return Ok(productDtos);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var productDtos = await productService.GetAllProductsWithStockAsync().ConfigureAwait(false);
        return Ok(productDtos);
    }
}
