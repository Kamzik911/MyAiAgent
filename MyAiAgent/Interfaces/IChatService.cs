using OpenAI.Chat;

namespace MyAiAgent.Interfaces
{
    public interface IChatService
    {
        List<ChatMessage> SystemMessage(string userMessage, CancellationToken cancToken = default);
        Task<string> AskAsync(string userMessage, CancellationToken cancToken = default);        
    }
}
