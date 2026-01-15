using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace JobTracker.Api.Controllers;

[ApiController]
[Route("api/health")]
public sealed class HealthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public HealthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("db")]
    public async Task<IActionResult> Db(CancellationToken ct)
    {
        var cs = _configuration.GetConnectionString("Main");
        if (string.IsNullOrWhiteSpace(cs))
            return Problem("Missing connection string: ConnectionStrings:Main");

        await using var conn = new NpgsqlConnection(cs);
        await conn.OpenAsync(ct);

        await using var cmd = new NpgsqlCommand("SELECT 1;", conn);
        var result = await cmd.ExecuteScalarAsync(ct);

        return Ok(new { db = "postgres", ok = true, result });
    }
}
