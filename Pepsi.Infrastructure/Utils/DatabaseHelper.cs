using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;
using System.Data;

namespace Pepsi.Infrastructure.Utils;
public class DatabaseHelper : IDatabaseHelper
{
    private readonly string? _connectionString;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public DatabaseHelper(IConfiguration configuration)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        _connectionString = configuration.GetConnectionString("PostgresConnection");
    }
    public ICustomDbConnection CreateConnection()
    {
        return new CustomDbConnectionWrapper(new NpgsqlConnection(_connectionString));
    }

    public bool CheckConnection()
    {
        using (var connection = CreateConnection())
        {
            try
            {
                connection.Open();

                var result = connection.ExecuteScalar("SELECT 'Connection is successful!'") as string;

                return result == "Connection is successful!";
            }
#pragma warning disable CA1031
            catch (Exception ex)
#pragma warning restore CA1031
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
