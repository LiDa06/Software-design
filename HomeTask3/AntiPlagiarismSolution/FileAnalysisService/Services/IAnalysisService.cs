using FileAnalysisService.Models;
public interface IAnalysisService
{
    Task<Report> AnalyzeAsync(string workId, string studentName, string text);
}