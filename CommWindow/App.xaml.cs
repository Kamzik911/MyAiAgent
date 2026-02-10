using System.Windows;
using CommWindow.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace CommWindow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider? _provider;
        public App() 
        {        
        }        
        private readonly ConfigMainWindow _configMainWindow;
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //registrace konfigurace a vlastní služby
            var services = new ServiceCollection();
            services.AddSingleton<AppConfigurations>();
            services.AddSingleton<ServiceSetup>();
            services.AddSingleton<ConfigMainWindow>();            

            _provider = services.BuildServiceProvider();

            //inicializace a spuštění
            var appConfig = _provider.GetRequiredService<AppConfigurations>();
            var config = appConfig.ConfigurationBuilderSetup();
            services.AddSingleton(config);

            _provider.GetRequiredService<ServiceSetup>().ChatServiceSetup(services, config);
            _provider.GetRequiredService<ConfigMainWindow>().ConfigWindow();
        }

        public void OnExitApp()
        {
            _configMainWindow.Dispose();            
        }
        
    }
}
