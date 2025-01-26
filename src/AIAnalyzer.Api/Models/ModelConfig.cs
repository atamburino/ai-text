namespace AIAnalyzer.Api.Models
{
    public class ModelConfig
    {
        public const string ModelName = "deepseek-coder-1.3b-base";
        public const string ModelVersion = "1.0";
        
        // Local storage paths - now relative to project directory
        public static string ModelDirectory => "Models";
        public static string TokenizerPath => Path.Combine(ModelDirectory, "tokenizer.json");
        public static string ModelPath => Path.Combine(ModelDirectory, "model.onnx");
        
        // Model parameters
        public const int MaxSequenceLength = 2048;
        public const int VocabSize = 32000;
    }
} 