using Microsoft.AspNetCore.Mvc;
namespace ApiGateway.Controllers;

[ApiController]
[Route("api")]
public class GatewayController(IHttpClientFactory factory) : ControllerBase
{
    private readonly IHttpClientFactory _factory = factory;

    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Upload(
    [FromForm] IFormFile file,
    [FromForm] string studentName,
    [FromForm] string assignment)
    {
        if (file == null)
            return BadRequest("file missing");

        var storageClient = _factory.CreateClient("storage");
        var multipart = new MultipartFormDataContent
        {
            { new StreamContent(file.OpenReadStream()), "file", file.FileName },
            { new StringContent(studentName), "studentName" },
            { new StringContent(assignment), "assignment" }
        };

        var storageResponse = await storageClient.PostAsync("/upload", multipart);
        if (!storageResponse.IsSuccessStatusCode)
            return StatusCode(500, "Storage failed");

        var analysisClient = _factory.CreateClient("analysis");
        var analysisResponse = await analysisClient.GetAsync($"/analyze/{studentName}");
        var analysisResult = await analysisResponse.Content.ReadAsStringAsync();

        return Ok(analysisResult);
    }


    [HttpGet("reports/{workId}")]
    public async Task<IActionResult> GetReports(string workId)
    {
        var client = _factory.CreateClient("analysis");
        var resp = await client.GetAsync($"/api/reports/{workId}");
        var body = await resp.Content.ReadAsStringAsync();
        return Content(body, "application/json");
    }
}
