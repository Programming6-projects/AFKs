using Moq;
using Pepsi.Core.Entities;
using Pepsi.Infrastructure.DatabaseAccess;
using Pepsi.Infrastructure.Repositories;

namespace Pepsi.Tests.Infrastructure.Repositories;

public class ProductRepositoryTests
{
    private readonly Mock<IDatabaseAccessor> _databaseAccessorMock;
    private readonly ProductRepository _productRepository;

    public ProductRepositoryTests()
    {
        _databaseAccessorMock = new Mock<IDatabaseAccessor>();
        _productRepository = new ProductRepository(_databaseAccessorMock.Object);
    }

    [Fact]
    public async Task GetProductsByNameAsyncShouldReturnCorrectProducts()
    {
        var productName = "Coca Cola";
        var expectedProducts = new List<Product> { new Product { Id = 1, Name = productName } };
        _databaseAccessorMock.Setup(x => x.QueryAsync<Product>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(expectedProducts);

        var result = await _productRepository.GetProductsByNameAsync(productName).ConfigureAwait(false);
        Assert.NotNull(result);
        var collection = result as Product[] ?? result.ToArray();
        Assert.Single(collection);
        Assert.Equal(productName, collection.First().Name);
    }

    [Fact]
    public async Task AddAsyncShouldInsertProductAndReturnId()
    {
        var newProduct = new Product { Name = "Coca Cola", Price = 10 };
        _databaseAccessorMock.Setup(x => x.ExecuteScalarAsync<int>(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync(1);
        var result = await _productRepository.AddAsync(newProduct).ConfigureAwait(false);
        Assert.Equal(1, result);
    }
}
