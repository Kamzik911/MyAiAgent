using MyAiAgent.Interfaces;
using MyAiAgent.Models;
using OpenAI.Chat;

namespace MyAiAgent.Methods
{
    public sealed class TestMethods : ITestMethods
    {
        private readonly ChatClient _chat;        

        public TestMethods(string apiKey, string model)
        {
            _chat = new ChatClient(
                model: model,
                apiKey: apiKey
            );                        
        }

        public async Task<GenerateTestsResponse> AskForEmailTests(FieldSpecification fieldSpec, string? prompt, CancellationToken cancToken = default)
        {
            var testDesignPrompt = new TestDesignPrompt();
            string systemPrompt = testDesignPrompt.systemPrompt;            
            var userPrompt = testDesignPrompt.userPrompt;
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
