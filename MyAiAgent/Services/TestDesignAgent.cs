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

        public async  Task MakeEmailTest()
        {
            var request = new GenerateTestsRequest
            {
                FieldType = "email",
                ValidationProfile = "rfc-ish"
            };

            await _methods.AskForEmailTests(request);
        }
    }
}
