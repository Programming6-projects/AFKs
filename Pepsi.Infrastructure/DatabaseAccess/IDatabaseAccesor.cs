namespace Pepsi.Infrastructure.DatabaseAccess;

public interface IDatabaseAccessor
{
    Task<T?> QuerySingleOrDefaultAsync<T>(string sql, object? param = null);
    Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null);
    Task<int> ExecuteScalarAsync<T>(string sql, object? param = null);
    Task<int> ExecuteAsync(string sql, object? param = null);
}
