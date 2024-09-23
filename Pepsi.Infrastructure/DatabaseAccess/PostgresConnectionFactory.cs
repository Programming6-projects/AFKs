using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Pepsi.Infrastructure.DatabaseAccess;

public class PostgresConnectionFactory(IConfiguration configuration) : IDbConnectionFactory
{
    private readonly string _connectionString = configuration.GetConnectionString("PostgresConnection")
                                                ?? throw new InvalidOperationException("PostgresConnection string is not configured.");

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
