namespace Pepsi.Infrastructure.FileAccess;

public class JsonFileReader : IFileReader
{
    public async Task<string> ReadFileAsync(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"The file {filePath} was not found.");
        }

        return await File.ReadAllTextAsync(filePath).ConfigureAwait(false);
    }
}
