using Pepsi.Infrastructure.FileAccess;
using Pepsi.Infrastructure.Serialization;

namespace Pepsi.Infrastructure.DataAccess;

public class JsonFileDataLoader<T>(IFileReader fileReader, ISerializer serializer) : IDataLoader<T>
    where T : class
{
    public async Task<IEnumerable<T>> LoadDataAsync(string source)
    {
        var jsonContent = await fileReader.ReadFileAsync(source).ConfigureAwait(false);
        return serializer.Deserialize<List<T>>(jsonContent) ?? new List<T>();
    }
}
