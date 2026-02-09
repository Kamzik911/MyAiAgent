namespace MyAiAgent.MyAiAgentCore
{
    public class AgentCore
    {
        public interface ItestDesignAgent
        {
            Task<string> AskAsync(string userRequest, CancellationToken cancellationToken);
        }
    }
}
