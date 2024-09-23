using System.Data;

namespace Pepsi.Infrastructure.DatabaseAccess;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}
