using Microsoft.AspNetCore.Mvc;
namespace FileAnalysisService.Controllers;

[ApiController]
[Route("api/reports")]
public class ReportsController(IAnalysisService an) : ControllerBase
{
    private readonly IAnalysisService _an = an;

    [HttpPost("analyze")]
    public async Task<IActionResult> Analyze([FromForm] string workId, [FromForm] string studentName, [FromForm] string text)
    {
        if (string.IsNullOrEmpty(text)) return BadRequest("text required");
        var report = await _an.AnalyzeAsync(workId, studentName, text);
        return Ok(report);
    }

    [HttpGet("{workId}")]
    public IActionResult GetByWork(string workId)
    {
        _ = _an switch
        {
            AnalysisService svc => svc,
            _ => null
        };
        return Ok(new { msg = "implement query to return reports for workId" });
    }
}
