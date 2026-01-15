using Microsoft.AspNetCore.Mvc;

namespace JobTracker.Modules.Applications.Api.Controllers;

[ApiController]
[Route("api/applications")]
public sealed class ApplicationsController : ControllerBase
{
    [HttpGet("ping")]
    public IActionResult Ping()
        => Ok(new { module = "applications", status = "ok" });
}
