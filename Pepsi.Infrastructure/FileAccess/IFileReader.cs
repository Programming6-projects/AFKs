namespace Pepsi.Infrastructure.FileAccess;

public interface IFileReader
{
    Task<string> ReadFileAsync(string filePath);
}
