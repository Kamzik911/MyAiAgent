using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAiAgent.Interfaces;
using MyAiAgent.Services;

namespace CommWindow.Configurations
{
    public class AppConfigurations : IAppConfigurations
    {
        private readonly ServiceCollection _serviceCollection;    
        private readonly ServiceSetup _serviceSetup;

        public AppConfigurations(ServiceCollection serviceCollection, ServiceSetup serviceSetup)
        {
            _serviceCollection = serviceCollection;
            _serviceSetup = serviceSetup;
        }
        public IConfiguration ConfigurationBuilderSetup()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets<App>()
                .Build();
            return config;
        }        

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _serviceCollection.AddSingleton(ConfigurationBuilderSetup());

            _serviceSetup.ChatServiceSetup();            
        }
    }
}
