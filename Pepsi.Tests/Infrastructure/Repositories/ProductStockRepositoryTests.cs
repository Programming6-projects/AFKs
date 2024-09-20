using Moq;
using Pepsi.Core.Entities;
using Pepsi.Infrastructure.DatabaseAccess;
using Pepsi.Infrastructure.Repositories;

namespace Pepsi.Tests.Infrastructure.Repositories;

public class ProductStockRepositoryTests
{
    private readonly Mock<IDatabaseAccessor> _databaseAccessorMock;
    private readonly ProductStockRepository _productStockRepository;

    public ProductStockRepositoryTests()
    {
        _databaseAccessorMock = new Mock<IDatabaseAccessor>();
        _productStockRepository = new ProductStockRepository(_databaseAccessorMock.Object);
    }

    [Fact]
    public async Task GetStockByProductIdAsyncShouldReturnCorrectStock()
    {
        var productId = 1;
        var expectedStock = new ProductStock { Id = 1, ProductId = productId, QuantityOnHand = 50, QuantityReserved = 0, QuantitySold = 0};
        _databaseAccessorMock.Setup(x => x.QuerySingleOrDefaultAsync<ProductStock>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(expectedStock);
        var result = await _productStockRepository.GetStockByProductIdAsync(productId).ConfigureAwait(false);
        Assert.NotNull(result);
        Assert.Equal(productId, result.ProductId);
    }

    [Fact]
    public async Task AddAsyncShouldInsertStockAndReturnId()
    {
        var newStock = new ProductStock { ProductId = 1,  QuantityOnHand = 50, QuantityReserved = 0, QuantitySold = 0 };
        _databaseAccessorMock.Setup(x => x.ExecuteScalarAsync<int>(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync(1);
        var result = await _productStockRepository.AddAsync(newStock).ConfigureAwait(false);
        Assert.Equal(1, result);
    }
}
