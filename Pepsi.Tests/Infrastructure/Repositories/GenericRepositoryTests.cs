using Moq;
using Pepsi.Core.Entities;
using Pepsi.Infrastructure.DatabaseAccess;
using Pepsi.Infrastructure.Repositories;

namespace Pepsi.Tests.Infrastructure.Repositories;


public class GenericRepositoryTests
{
    private readonly Mock<IDatabaseAccessor> _mockDbAccessor;
    private readonly TestRepository _repository;

    public GenericRepositoryTests()
    {
        _mockDbAccessor = new Mock<IDatabaseAccessor>();
        _repository = new TestRepository(_mockDbAccessor.Object);
    }

    [Fact]
    public async Task GetByIdAsyncShouldReturnEntity()
    {
        var expectedEntity = new TestEntity { Id = 1, Name = "Test" };
        _mockDbAccessor.Setup(db => db.QuerySingleOrDefaultAsync<TestEntity>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(expectedEntity);
        var result = await _repository.GetByIdAsync(1).ConfigureAwait(false);
        Assert.Equal(expectedEntity, result);
    }

    [Fact]
    public async Task GetAllAsyncShouldReturnEntities()
    {
        var expectedEntities = new List<TestEntity> { new TestEntity { Id = 1, Name = "Test1" }, new TestEntity { Id = 2, Name = "Test2" } };
        _mockDbAccessor.Setup(db => db.QueryAsync<TestEntity>(It.IsAny<string>(), null))
            .ReturnsAsync(expectedEntities);
        var result = await _repository.GetAllAsync().ConfigureAwait(false);
        Assert.Equal(expectedEntities, result);
    }

    [Fact]
    public async Task AddAsyncShouldReturnId()
    {
        var entity = new TestEntity { Name = "Test" };
        _mockDbAccessor.Setup(db => db.ExecuteScalarAsync<int>(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);
        var result = await _repository.AddAsync(entity).ConfigureAwait(false);
        Assert.Equal(1, result);
    }

    [Fact]
    public async Task UpdateAsyncShouldExecuteQuery()
    {
        var entity = new TestEntity { Id = 1, Name = "Updated" };
        _mockDbAccessor.Setup(db => db.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);
        await _repository.UpdateAsync(entity).ConfigureAwait(false);
        _mockDbAccessor.Verify(db => db.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
    }

    [Fact]
    public async Task DeleteAsyncShouldExecuteQuery()
    {
        _mockDbAccessor.Setup(db => db.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(1);
        await _repository.DeleteAsync(1).ConfigureAwait(false);
        _mockDbAccessor.Verify(db => db.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
    }

    private sealed class TestEntity : BaseEntity
    {
        public string? Name { get; set; }
    }

    private sealed class TestRepository(IDatabaseAccessor dbAccessor)
        : GenericRepository<TestEntity>(dbAccessor, "TestEntities");
}
