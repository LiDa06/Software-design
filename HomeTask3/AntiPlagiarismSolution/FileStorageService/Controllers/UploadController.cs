using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/files")]
public class UploadController(IFileStorage storage, AppDbContext db) : ControllerBase
{
    private readonly IFileStorage _storage = storage;
    private readonly AppDbContext _db = db;

    [HttpPost("upload")]
    public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromForm] string studentName, [FromForm] string assignment)
    {
        if (file == null) return BadRequest("file missing");
        var workId = Guid.NewGuid().ToString();
        var path = await _storage.SaveFileAsync(workId, file);

        var w = new StudentWork
        {
            WorkId = workId,
            StudentName = studentName,
            AssignmentName = assignment,
            FilePath = path,
            UploadedAt = DateTime.UtcNow
        };
        _db.Works.Add(w);
        await _db.SaveChangesAsync();

        return Ok(new { workId });
    }

    [HttpGet("{workId}")]
    public IActionResult Get(string workId)
    {
        var w = _db.Works.FirstOrDefault(x => x.WorkId == workId);
        if (w == null) return NotFound();
        return Ok(w);
    }
}
