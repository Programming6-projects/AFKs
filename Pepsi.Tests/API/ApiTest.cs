using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Pepsi.Infrastructure.Utils;

namespace Pepsi.Tests.API;

public class ApiTest
{
    [Fact]
    public void CheckConnectionShouldReturnOkWhenDatabaseConnectionIsSuccessful()
    {
        var mockDatabaseHelper = new Mock<IDatabaseHelper>();
        mockDatabaseHelper.Setup(db => db.CheckConnection()).Returns(true);
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddScoped(_ => mockDatabaseHelper.Object);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var dbHelper = serviceProvider.GetRequiredService<IDatabaseHelper>();
        var result = CheckConnection(dbHelper);
        var okResult = Assert.IsType<Ok<string>>(result);
        Assert.Equal("Database connection is successful!", okResult.Value);
    }

    [Fact]
    public void CheckConnectionShouldReturnStatus500WhenDatabaseConnectionFails()
    {
        var mockDatabaseHelper = new Mock<IDatabaseHelper>();
        mockDatabaseHelper.Setup(db => db.CheckConnection()).Returns(false);
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddScoped(_ => mockDatabaseHelper.Object);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var dbHelper = serviceProvider.GetRequiredService<IDatabaseHelper>();
        var result = CheckConnection(dbHelper);
        var statusCodeResult = Assert.IsType<StatusCodeHttpResult>(result);
        Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
    }

    private static IResult CheckConnection(IDatabaseHelper dbHelper)
    {
        var isConnected = dbHelper.CheckConnection();
        return isConnected ? Results.Ok("Database connection is successful!") : Results.StatusCode(500);
    }
}
