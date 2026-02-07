using MyAiAgent.Models;

namespace MyAiAgent
{
    public interface ITestMethods
    {
        Task<GenerateTestsResponse> AskForEmailTests(
            GenerateTestsRequest request,
            CancellationToken cancToken = default
            );
    }

    public interface ITestDesignAgent
    {
     
    }
}
