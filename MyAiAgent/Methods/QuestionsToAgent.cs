using MyAiAgent.Interfaces;
using MyAiAgent.Models;
using OpenAI.Chat;

namespace MyAiAgent.Methods
{
    public sealed class QuestionsToAgent : IQuestionsToAgent
    {
        private readonly ChatClient _chat;
        private readonly ITestMethods _methods;
        private readonly IGeneralChatAgent _generalAgent;

        public QuestionsToAgent(ITestMethods methods, IGeneralChatAgent generalAgent)
        {
            _methods = methods;               
            _generalAgent = generalAgent;
        }

        public Task<GenerateTestsResponse> EmailQuestionGenerateAsync(FieldSpecification fieldSpec, string? prompt, CancellationToken cancToken = default)
        {
            return _methods.AskForEmailTests(fieldSpec, prompt, cancToken);
        }

        public async Task<string> AskAsync(string userRequest, CancellationToken cancToken = default)
        {
            var messages = new List<ChatMessage>
            {
                new SystemChatMessage("You are a helpful assistant that generates email test cases based on user requests."),
                new UserChatMessage(userRequest)
            };
            var response = await _chat.CompleteChatAsync(messages, options: null, cancellationToken: cancToken);
            return response.Value.Content[0].Text;
        }
    }
}
