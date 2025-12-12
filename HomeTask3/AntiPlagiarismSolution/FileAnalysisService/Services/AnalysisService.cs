using FileAnalysisService.Models;
public class AnalysisService : IAnalysisService
{
    private readonly AppDbContext _db;
    public AnalysisService(AppDbContext db) { _db = db; }

    public async Task<Report> AnalyzeAsync(string workId, string studentName, string text)
    {
        var hash = ComputeHash(text);
        // Простое правило: плагиат если совпал хеш с другим workId
        var isPlag = _db.Reports.Any(r => r.TextHash == hash && r.WorkId != workId);

        var r = new Report
        {
            WorkId = workId,
            StudentName = studentName,
            TextHash = hash,
            IsPlagiarism = isPlag,
            CreatedAt = DateTime.UtcNow
        };
        _db.Reports.Add(r);
        await _db.SaveChangesAsync();
        return r;
    }

    private string ComputeHash(string s)
    {
        using var sha = System.Security.Cryptography.SHA256.Create();
        return Convert.ToHexString(sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(s)));
    }
}