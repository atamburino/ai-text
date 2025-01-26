using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace AIAnalyzer.Api.Services
{
    public class MLService : IDisposable
    {
        private readonly ILogger<MLService> _logger;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public MLService(ILogger<MLService> logger, IConfiguration configuration, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
            
            _apiKey = Environment.GetEnvironmentVariable("DEEPSEEK_API_KEY");
            var baseUrl = configuration["Deepseek:BaseUrl"];
            
            _logger.LogInformation($"Initializing MLService with API Key: {_apiKey?.Substring(0, 10)}... and Base URL: {baseUrl}");

            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new Exception("DEEPSEEK_API_KEY environment variable is not set");
            }

            if (string.IsNullOrEmpty(baseUrl))
            {
                throw new Exception("Deepseek base URL not found in configuration");
            }

            _httpClient.BaseAddress = new Uri(baseUrl);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
        }

        public async Task<string> AnalyzeText(string text)
        {
            try
            {
                _logger.LogInformation($"Analyzing text: {text}");

                var request = new
                {
                    model = "deepseek-coder-6.7b-instruct",
                    messages = new[]
                    {
                        new { role = "system", content = "You are an AI text analysis assistant. Analyze the following text and provide insights about its content, tone, and key points." },
                        new { role = "user", content = text }
                    },
                    temperature = 0.7,
                    max_tokens = 1000
                };

                _logger.LogInformation($"Sending request to: {_httpClient.BaseAddress}/chat/completions");
                var response = await _httpClient.PostAsJsonAsync("/chat/completions", request);
                
                _logger.LogInformation($"Response status code: {response.StatusCode}");
                var responseContent = await response.Content.ReadAsStringAsync();
                _logger.LogInformation($"Response content: {responseContent}");
                
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadFromJsonAsync<JsonElement>();
                return result.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString() ?? "No response generated";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error analyzing text with Deepseek");
                throw;
            }
        }

        public void Dispose()
        {
            // No cleanup needed
        }
    }
}