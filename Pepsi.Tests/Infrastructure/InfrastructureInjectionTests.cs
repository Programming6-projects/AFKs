using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pepsi.Core.Interfaces.Repositories;
using Pepsi.Infrastructure;
using Pepsi.Infrastructure.DatabaseAccess;
using Pepsi.Infrastructure.FileAccess;
using Pepsi.Infrastructure.Serialization;

namespace Pepsi.Tests.Infrastructure;

public class InfrastructureInjectionTests
{
    private readonly IServiceCollection _services = new ServiceCollection();
    private readonly IConfiguration _configuration;

    public InfrastructureInjectionTests()
    {
        _configuration = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string>
        {
            { "ConnectionStrings:PostgresConnection", "Host=localhost;Port=5432;Database=mydb;Username=myuser;Password=mypassword" }
        }!).Build();

        _services.AddSingleton(_configuration);
    }

    [Fact]
    public void AddInfrastructureShouldRegisterRequiredServices()
    {
        _services.AddInfrastructure(_configuration);
        var serviceProvider = _services.BuildServiceProvider();

        Assert.NotNull(serviceProvider.GetService<IDbConnectionFactory>());
        Assert.NotNull(serviceProvider.GetService<IDatabaseAccessor>());
        Assert.NotNull(serviceProvider.GetService<IFileReader>());
        Assert.NotNull(serviceProvider.GetService<ISerializer>());
        Assert.NotNull(serviceProvider.GetService<IClientRepository>());
    }
}
