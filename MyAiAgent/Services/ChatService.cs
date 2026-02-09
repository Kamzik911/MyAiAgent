using OpenAI.Chat;
using MyAiAgent.Interfaces;

namespace MyAiAgent.Services
{
    public sealed class ChatService : IChatService
    {
        private readonly ChatClient _client;

        private string systemMessage = "You are a helpful assistant.";

        public ChatService(string apiKey, string model)
        {
            _client = new ChatClient(model: model, apiKey: apiKey);
        }        

        public async Task<string> AskAsync(string userMessage, CancellationToken cancToken = default)
        {
            var chatMessage = new List<ChatMessage>
            {
                new SystemChatMessage(systemMessage),
                new UserChatMessage(userMessage)
            };

            var response = await _client.CompleteChatAsync(chatMessage, options: null, cancellationToken: cancToken);
            return response.Value.Content[0].Text;
        }
    }
}
