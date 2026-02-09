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
        private ServiceCollection _serviceCollection;

        public App(ServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
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

        public void ConfigMainWindow()
        {
            _serviceCollection.AddSingleton<MainWindow>();
            _provider = _serviceCollection.BuildServiceProvider();
            var mainWindow = _provider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _serviceCollection.AddSingleton(ConfigurationBuilderSetup());

            _serviceCollection.AddSingleton<IChatService>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var apiKey = configuration["OpenAI:ApiKey"];
                var model = configuration["OpenAI:Model"];                
                return new ChatService(apiKey, model);                
            });

            ConfigMainWindow();
        }
    }
}
