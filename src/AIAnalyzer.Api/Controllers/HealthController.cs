using Microsoft.AspNetCore.Mvc;

namespace AIAnalyzer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet("status")]
        public IActionResult GetStatus()
        {
            return Ok(new { status = "Healthy", timestamp = DateTime.UtcNow });
        }
    }
}
