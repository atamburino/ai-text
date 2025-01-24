using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AIAnalyzer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalysisController : ControllerBase
    {
        private readonly ILogger<AnalysisController> _logger;

        public AnalysisController(ILogger<AnalysisController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Analysis endpoint working!");
        }

        [HttpGet("analyze")]
        public IActionResult Analyze(string text) {
            // Mock analysis
            return Ok(new { Text = text, Analysis = "This is a placeholder analysis." });
        }
    }

    public class AnalysisRequest {
        public string Text { get; set; }
    }
}