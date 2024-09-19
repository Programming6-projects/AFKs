using Microsoft.AspNetCore.Mvc;
using Pepsi.Core.Interfaces.Services;

namespace Pepsi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var productDto = await _productService.GetProductByIdWithStockAsync(id).ConfigureAwait(false);
        if (productDto == null)
        {
            return NotFound();
        }

        return Ok(productDto);
    }

    [HttpGet("search")]
    public async Task<IActionResult> GetProductsByName(string name)
    {
        var productDtos = await _productService.GetProductsByNameAsync(name).ConfigureAwait(false);
        return Ok(productDtos);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var productDtos = await _productService.GetAllProductsWithStockAsync().ConfigureAwait(false);
        return Ok(productDtos);
    }
}


