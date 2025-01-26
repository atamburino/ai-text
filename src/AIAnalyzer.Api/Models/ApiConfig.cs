namespace AIAnalyzer.Api.Models
{
    public class ApiConfig
    {
        public const string ApiEndpoint = "https://api.deepseek.com/v1";
        public const string ModelName = "deepseek-coder-1.3b-base";
        
        // This will be loaded from configuration
        public static string ApiKey => Environment.GetEnvironmentVariable("DEEPSEEK_API_KEY");
    }
} 