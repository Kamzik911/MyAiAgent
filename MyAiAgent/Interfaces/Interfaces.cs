using MyAiAgent.Models;

namespace MyAiAgent.Interfaces
{
    public interface ITestMethods
    {
        Task<GenerateTestsResponse> AskForEmailTests(FieldSpecification fieldSpec, string? prompt, CancellationToken cancToken = default);
    }

    public interface ITestDesignAgent
    {
        Task<GenerateTestsResponse>GenerateAsync(FieldSpecification fieldSpec, string? prompt, CancellationToken cancToken = default);
        Task<string> AskAsync(string userRequest, CancellationToken cancToken = default);
    }
}
