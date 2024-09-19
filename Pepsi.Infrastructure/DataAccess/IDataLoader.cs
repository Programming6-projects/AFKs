namespace Pepsi.Infrastructure.DataAccess;

public interface IDataLoader<T> where T : class
{
    Task<IEnumerable<T>> LoadDataAsync(string source);
}
