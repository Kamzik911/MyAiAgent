using MyAiAgent.Models;

namespace MyAiAgent
{
    public interface ITestMethods
    {
        Task<GenerateTestsResponse> AskForEmailTests(FieldSpecification request, CancellationToken cancToken = default);
    }

    public interface ITestDesignAgent
    {
        Task<GenerateTestsResponse>GenerateAsync(FieldSpecification fieldSpec, CancellationToken cancToken = default);
    }
}
