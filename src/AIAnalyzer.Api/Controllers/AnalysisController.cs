using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("analyze")]
        public async Task<IActionResult> Analyze([FromBody] AnalysisRequest request)
        {
            if (string.IsNullOrEmpty(request?.Text))
            {
                return BadRequest("Text to analyze is required");
            }

            var analysis = await _mlService.AnalyzeText(request.Text);
            return Ok(new { Text = request.Text, Analysis = analysis });
        }
    }

    public class AnalysisRequest
    {
        public string Text { get; set; }
    }
}