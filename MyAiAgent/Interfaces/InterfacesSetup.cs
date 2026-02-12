using OpenAI.Chat;

namespace MyAiAgent.Interfaces
{
    public interface IMessageBuilder
    {
        List<ChatMessage> SystemMessage(string userMessage, CancellationToken cancToken = default);               
    }

    public interface IChatCompletionClient
    {
        Task<string> AskAsync(string userMessage, CancellationToken cancToken = default);
    }

    public interface IWindowMessages
    {
        string MainMessage();
    }
}
