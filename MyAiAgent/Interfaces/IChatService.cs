
namespace MyAiAgent.Interfaces
{
    public interface IChatService
    {
        Task<string> AskAsync(string userMessage, CancellationToken cancToken = default);
    }
}
