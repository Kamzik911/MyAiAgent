using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAiAgent.Interfaces;
using MyAiAgent.Services;

namespace CommWindow.Configurations
{
    public class ServiceSetup : IServiceSetup
    {

        public void ChatServiceSetup(IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IChatService>(sp =>
                new ChatService(config["OpenAI:ApiKey"], config["OpenAI:Model"]));
        }        
    }
}
