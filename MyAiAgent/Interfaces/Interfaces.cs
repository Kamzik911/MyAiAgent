using MyAiAgent.Models;

namespace MyAiAgent.Interfaces
{
    public interface ITestMethods
    {
        Task<GenerateTestsResponse> AskForEmailTests(FieldSpecification request, string? userPrompt, CancellationToken cancToken = default);
    }

    public interface ITestDesignAgent
    {
        Task<GenerateTestsResponse>GenerateAsync(FieldSpecification request, string? userPrompt, CancellationToken cancToken = default);
        Task<string> AskAsync(string userRequest, CancellationToken cancToken = default);
    }
}
