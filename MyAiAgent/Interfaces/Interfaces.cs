using MyAiAgent.Models;

namespace MyAiAgent.Interfaces
{
    public interface ITestMethods
    {
        Task<GenerateTestsResponse> AskForEmailTests(string? prompt, CancellationToken cancToken = default);
    }

    public interface ITestDesignAgent
    {
        Task<GenerateTestsResponse>GenerateAsync(string? prompt, CancellationToken cancToken = default);
        Task<string> AskAsync(string userRequest, CancellationToken cancToken = default);
    }
}
