using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAiAgent;
using MyAiAgent.Services;

namespace CommWindow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _provider = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json", optional: true).Build();
            
            var services = new ServiceCollection();

            //Konfigurace (pro případnou injekci)
            services.AddSingleton<IConfiguration>(config);

            //Registrace logiky z MyAiAgent
            services.AddSingleton<ITestDesignAgent, TestDesignAgent>();

            //WPF okna
            services.AddSingleton<MainWindow>();

            _provider = services.BuildServiceProvider();

            var mainWindow = _provider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }

}
