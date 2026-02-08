using MyAiAgent.Models;
using OpenAI.Chat;

namespace MyAiAgent.Methods
{
    public sealed class TestMethods : ITestMethods
    {
        private readonly ChatClient _chat;
        private readonly TestDesignPrompt _testDesignPrompt;

        public TestMethods(string apiKey, string model, TestDesignPrompt systemPrompt)
        {
            _chat = new ChatClient(
                model: model,
                apiKey: apiKey
            );
            _testDesignPrompt = systemPrompt;
        }        

        public async Task<GenerateTestsResponse> AskForEmailTests(FieldSpecification fieldSpec, CancellationToken cancToken = default)
        {
            string systemPrompt = _testDesignPrompt.systemPrompt;

            var userPrompt = _testDesignPrompt.userPrompt;

            var messages = new List<ChatMessage>
            {
                new SystemChatMessage(systemPrompt),
                new UserChatMessage(userPrompt),
            };

            var response = await _chat.CompleteChatAsync(messages, options: null, cancellationToken: cancToken);

            var content = response.Value.Content[0].Text;

            return new GenerateTestsResponse
            {
                Markdown = content
            };
        }
    }
}
