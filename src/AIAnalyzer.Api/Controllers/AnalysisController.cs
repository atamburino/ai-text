using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AIAnalyzer.Api.Services;

namespace AIAnalyzer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnalysisController : ControllerBase
    {
        private readonly ILogger<AnalysisController> _logger;
        private readonly MLService _mlService;

        public AnalysisController(ILogger<AnalysisController> logger, MLService mlService)
        {
            _logger = logger;
            _mlService = mlService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Analysis endpoint working!");
        }

        [HttpGet("analyze")]
        public async Task<IActionResult> Analyze(string text)
        {
            var analysis = await _mlService.AnalyzeText(text);
            return Ok(new { Text = text, Analysis = analysis });
        }
    }

    public class AnalysisRequest {
        public string Text { get; set; }
    }
}