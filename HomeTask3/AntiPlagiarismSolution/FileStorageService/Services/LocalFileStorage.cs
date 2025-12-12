public class LocalFileStorage : IFileStorage
{
    private readonly string _root;
    public LocalFileStorage(IConfiguration cfg)
    {
        _root = cfg.GetValue<string>("FileStorage:Root") ?? "/files";
        Directory.CreateDirectory(_root);
    }

    public async Task<string> SaveFileAsync(string workId, IFormFile file)
    {
        var ext = Path.GetExtension(file.FileName);
        var name = $"{workId}{ext}";
        var path = Path.Combine(_root, name);
        using var fs = System.IO.File.Create(path);
        await file.OpenReadStream().CopyToAsync(fs);
        return path;
    }

    public Task<Stream?> OpenReadAsync(string filePath)
    {
        if (!System.IO.File.Exists(filePath)) return Task.FromResult<Stream?>(null);
        return Task.FromResult<Stream?>(System.IO.File.OpenRead(filePath));
    }
}
