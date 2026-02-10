using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAiAgent.Interfaces;
using MyAiAgent.Services;

namespace CommWindow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider? _provider;
        private ServiceCollection _serviceColl = new ServiceCollection();        
        
        public IConfiguration ConfigurationBuilderSetup()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets<App>()
                .Build();
            return config;
        }

        public void ConfigMainWindow()
        {
            _serviceColl.AddSingleton<MainWindow>();
            _provider = _serviceColl.BuildServiceProvider();
            var mainWindow = _provider.GetRequiredService<MainWindow>();
            mainWindow.Show();
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

        public void Dispose()
        {
            if (_provider != null)
            {
                _provider.Dispose();
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _serviceColl.AddSingleton(ConfigurationBuilderSetup());            
                        
            ConfigMainWindow();
            ChatServiceSetup();
            Dispose();
        }
    }
}
