public interface IFileStorage
{
    Task<string> SaveFileAsync(string workId, IFormFile file);
    Task<Stream?> OpenReadAsync(string filePath);
}
