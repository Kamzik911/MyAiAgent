using Microsoft.AspNetCore.DataProtection.KeyManagement;
using MyAiAgent.Interfaces;
using OpenAI.Chat;

namespace MyAiAgent.Services
{
    public class ChatCompletionClient : IChatCompletionClient
    {
        private readonly ChatClient _client;
        private readonly MessageBuilder _messageBuilder;
        
        public ChatCompletionClient(ChatClient client, MessageBuilder messageBuilder)
        {
            _client = client;
            _messageBuilder = messageBuilder;
        }

        public async Task<string> AskAsync(string userMessage, CancellationToken cancToken = default)
        {
            List<ChatMessage> chatMessage = _messageBuilder.SystemMessage(userMessage, cancToken);

            var response = await _client.CompleteChatAsync(chatMessage, options: null, cancellationToken: cancToken);
            return response.Value.Content[0].Text;
        }
    }
}
