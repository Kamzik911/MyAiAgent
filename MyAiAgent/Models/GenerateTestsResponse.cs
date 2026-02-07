namespace MyAiAgent.Models
{
    public sealed class GenerateTestsResponse
    {
        public string Markdown { get; set; } = "";
        public object? Json { get; set; } //Will be typed
        public List<string> OpenQuestions { get; set; } = new();
    }
}
