using MyAiAgent.Models;

namespace MyAiAgent.Services
{
    public sealed class TestDesignAgent : ITestDesignAgent
    {
        private readonly ITestMethods _methods;        

        public TestDesignAgent(ITestMethods methods)
        {
            _methods = methods;               
        }

        public Task<GenerateTestsResponse> GenerateAsync(FieldSpecification fieldSpec, CancellationToken cancToken = default)
        {
            return _methods.AskForEmailTests(fieldSpec, cancToken);
        }

        public async Task<string> AskAsync(string userRequest, CancellationToken cancToken = default)
        {
            await Task.Delay(500);
            return $"Agent received: {userRequest}";
        }
    }
}
