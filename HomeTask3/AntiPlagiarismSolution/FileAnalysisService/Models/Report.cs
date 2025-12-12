namespace FileAnalysisService.Models;
public class Report
{
    public string ReportId { get; set; } = Guid.NewGuid().ToString();
    public string WorkId { get; set; } = string.Empty;
    public string StudentName { get; set; } = string.Empty;
    public string TextHash { get; set; } = string.Empty;
    public bool IsPlagiarism { get; set; }
    public DateTime CreatedAt { get; set; }
}
