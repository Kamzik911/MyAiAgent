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
        public App() { }

        public void ConfigureServices(IServiceCollection services)
        {
            //registrace konfigurace tak, aby DI znalo Iconfiguration
            var config = new AppConfigurations().ConfigurationBuilderSetup();
            services.AddSingleton(config);

            // registrace ServiceSetup a dalších služeb
            services.AddSingleton<ServiceSetup>();
            //Registrace chat service
            new ServiceSetup().ChatServiceSetup(services, config);

            //Registrase MainWindow
            services.AddSingleton<MainWindow>();
        }

        public void BuilServiceProvider(IServiceCollection services)
        {
            _provider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();            

            base.OnStartup(e);            

            ConfigureServices(services);
            BuilServiceProvider(services);
            
            //Zobrazení hlavního okna
            var mainWindow = _provider?.GetRequiredService<MainWindow>();
            mainWindow?.Show();
        }
        
    }
}
