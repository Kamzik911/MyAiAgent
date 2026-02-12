using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAiAgent.Services;
using OpenAI.Chat;


namespace CommWindow.Configurations
{
    public class ServiceSetup : IServiceSetup
    {
        public void ChatServiceSetup(IServiceCollection services, IConfiguration config)
        {
            var apiKey = config["OpenAI:ApiKey"];
            var model = config["OpenAI:Model"];
            
            services.AddSingleton(_ => new ChatClient(model, apiKey));
            services.AddSingleton<MessageBuilder>();
            services.AddSingleton<ChatCompletionClient>();
        }        
    }
}
