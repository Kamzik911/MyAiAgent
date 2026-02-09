using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAiAgent.Interfaces;
using MyAiAgent.Methods;
using MyAiAgent.Models;
using MyAiAgent.Services;

namespace CommWindow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider? _provider;        

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets<App>()
                .Build();
            
            var services = new ServiceCollection();                        
            services.AddSingleton<IConfiguration>(config);                        
            
            services.AddSingleton<FieldSpecification>();                        
            services.AddSingleton<ITestMethods>(sp =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                var apiKey = configuration["OpenAI:ApiKey"];
                var model = configuration["OpenAI:Model"];

                if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(model))
                {
                    throw new InvalidOperationException("Missing OpenAI configuration. Set OpenAI:ApiKey and OpenAI:Model in appsettings.json.");
                }
                var fieldSpec = sp.GetRequiredService<FieldSpecification>();
                return new TestMethods(apiKey, model, fieldSpec);                
            });

            services.AddTransient<ITestDesignAgent, TestDesignAgent>();                        
            services.AddSingleton<MainWindow>();

            _provider = services.BuildServiceProvider();
            var mainWindow = _provider.GetRequiredService<MainWindow>();
            mainWindow.Show();            
        }
    }
}
