using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAiAgent.Interfaces;
using MyAiAgent.Services;

namespace CommWindow.Configurations
{
    public class ServiceSetup : IServiceSetup
    {        
        private readonly IServiceCollection _serviceColl;

        public ServiceSetup(ServiceCollection serviceColl)
        {
            _serviceColl = serviceColl;
        }
        public IServiceCollection ChatServiceSetup()
        {
            var chatSetup = _serviceColl.AddSingleton<IChatService>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var apiKey = configuration["OpenAI:ApiKey"];
                var model = configuration["OpenAI:Model"];
                return new ChatService(apiKey, model);
            });
            return chatSetup;
        }
    }
}
