using OpenAI.Chat;
using MyAiAgent.Interfaces;

namespace MyAiAgent.Services
{
    public sealed class MessageBuilder : IMessageBuilder
    {
        private readonly WindowMessages _windowMessages = new WindowMessages();
        
        public List<ChatMessage> SystemMessage(string userMessage, CancellationToken cancToken = default)
        {
            var chatMessage = new List<ChatMessage>
            {
                new SystemChatMessage(_windowMessages.MainMessage()),
                new UserChatMessage(userMessage)
            };
            return chatMessage;
        }        
    }
}
