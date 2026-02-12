using MyAiAgent.Interfaces;

namespace MyAiAgent.Services
{
    public class WindowMessages : IWindowMessages
    {
        string mainMessage = "You are a helpful assistant.";

        public string MainMessage()
        {
            return mainMessage;
        }
    }
}
