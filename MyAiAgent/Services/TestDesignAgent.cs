using MyAiAgent.Models;

namespace MyAiAgent.Services
{
    public sealed class TestDesignAgent
    {
        private readonly ITestMethods _methods;

        public TestDesignAgent(ITestMethods methods)
        {
            _methods = methods;
        }

        public Task<GenerateTestsResponse> GenerateAsync(GenerateTestsRequest request, CancellationToken cancToken = default)
        {
            return _methods.AskForEmailTests(request, cancToken);
        }
    }
}
