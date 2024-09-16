namespace Pepsi.Infrastructure.Utils;

public interface ICustomDbConnection : IDisposable
{
    void Open();
    void Close();
    object ExecuteScalar(string sql);
}
