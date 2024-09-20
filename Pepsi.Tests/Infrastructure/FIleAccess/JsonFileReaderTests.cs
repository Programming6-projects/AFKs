using Pepsi.Infrastructure.FileAccess;

namespace Pepsi.Tests.Infrastructure.FIleAccess;

public class JsonFileReaderTests
{
    private readonly JsonFileReader _fileReader = new();
    private readonly string _testFilePath = Path.GetTempFileName();

    [Fact]
    public async Task ReadFileAsyncExistingFileShouldReturnContent()
    {
        var expectedContent = "{\"test\": \"content\"}";
        await File.WriteAllTextAsync(_testFilePath, expectedContent).ConfigureAwait(false);
        var result = await _fileReader.ReadFileAsync(_testFilePath).ConfigureAwait(false);
        Assert.Equal(expectedContent, result);
    }

    [Fact]
    public async Task ReadFileAsyncNonExistentFileShouldThrowFileNotFoundException()
    {
        var nonExistentFilePath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        await Assert.ThrowsAsync<FileNotFoundException>(() => _fileReader.ReadFileAsync(nonExistentFilePath)).ConfigureAwait(false);
    }

    [Fact]
    public async Task ReadFileAsyncShouldReturnFileContentWhenFileExists()
    {
        var filePath = "Data/Vehicles.json";
        var fileContent = "{\"Id\": 1, \"Name\": \"Client A\"}";
        await File.WriteAllTextAsync(filePath, fileContent).ConfigureAwait(false);
        var result = await _fileReader.ReadFileAsync(filePath).ConfigureAwait(false);
        Assert.Equal(fileContent, result);
        File.Delete(filePath);
    }

    [Fact]
    public async Task ReadFileAsyncShouldThrowFileNotFoundExceptionWhenFileDoesNotExist()
    {
        var filePath = "invalid/path/to/file.json";
        await Assert.ThrowsAsync<FileNotFoundException>(() => _fileReader.ReadFileAsync(filePath)).ConfigureAwait(false);
    }
}
