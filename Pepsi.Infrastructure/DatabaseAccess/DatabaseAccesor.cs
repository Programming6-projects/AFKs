using Dapper;

namespace Pepsi.Infrastructure.DatabaseAccess;

public class DatabaseAccessor(IDbConnectionFactory connectionFactory) : IDatabaseAccessor
{
    public async Task<T?> QuerySingleOrDefaultAsync<T>(string sql, object? param = null)
    {
        using var connection = connectionFactory.CreateConnection();
        return await connection.QuerySingleOrDefaultAsync<T>(sql, param).ConfigureAwait(false);
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null)
    {
        using var connection = connectionFactory.CreateConnection();
        return await connection.QueryAsync<T>(sql, param).ConfigureAwait(false);
    }

    public async Task<int> ExecuteScalarAsync<T>(string sql, object? param = null)
    {
        using var connection = connectionFactory.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(sql, param).ConfigureAwait(false);
    }

    public async Task<int> ExecuteAsync(string sql, object? param = null)
    {
        using var connection = connectionFactory.CreateConnection();
        return await connection.ExecuteAsync(sql, param).ConfigureAwait(false);
    }
}
