using MyAiAgent.Models;

namespace MyAiAgent.Services
{
    public sealed class TestDesignAgent : ITestDesignAgent
    {
        private readonly ITestMethods _methods;
        private readonly ITestDesignAgent _designAgent;

        public TestDesignAgent(ITestMethods methods, ITestDesignAgent designAgent)
        {
            _methods = methods;
            _designAgent = designAgent;
        }

        public Task<GenerateTestsResponse> GenerateAsync(FieldSpecification fieldSpec, CancellationToken cancToken = default)
        {
            return _methods.AskForEmailTests(fieldSpec, cancToken);
        }
    }
}
