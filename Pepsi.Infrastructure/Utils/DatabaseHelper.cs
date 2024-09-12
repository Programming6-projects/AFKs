using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;
using System.Data;

namespace Pepsi.Infrastructure.Utils;
public class DatabaseHelper
{
    private readonly string _connectionString;

    public DatabaseHelper(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("PostgresConnection");
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }

    public bool CheckConnection()
    {
        using (var connection = CreateConnection())
        {
            try
            {
                connection.Open();

                var result = connection.ExecuteScalar<string>("SELECT 'Connection is successful!'");

                return result == "Connection is successful!";
            }
            catch (Exception ex)
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
