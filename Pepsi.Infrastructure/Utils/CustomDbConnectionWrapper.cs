using System.Data;
using Dapper;

namespace Pepsi.Infrastructure.Utils;

public sealed class CustomDbConnectionWrapper : ICustomDbConnection
{
    private readonly IDbConnection _connection;

    public CustomDbConnectionWrapper(IDbConnection connection)
    {
        _connection = connection;
    }

    public void Open() => _connection.Open();
    public void Close() => _connection.Close();
#pragma warning disable CS8603 // Possible null reference return.
    public object ExecuteScalar(string sql) => _connection.ExecuteScalar(sql);
#pragma warning restore CS8603 // Possible null reference return.
    public void Dispose() => _connection.Dispose();
}
