public class StudentWork
{
    public string WorkId { get; set; } = Guid.NewGuid().ToString();
    public string StudentName { get; set; } = string.Empty;
    public string AssignmentName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public DateTime UploadedAt { get; set; }
}
