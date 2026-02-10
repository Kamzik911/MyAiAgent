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
        
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
                        
            //registrace konfigurace tak, aby DI znalo Iconfiguration
            var services = new ServiceCollection();
            var config = new AppConfigurations().ConfigurationBuilderSetup();
            services.AddSingleton(config);
            
            // registrace ServiceSetup a dalších služeb
            services.AddSingleton<ServiceSetup>();            

            //Registrace chat service
            new ServiceSetup().ChatServiceSetup(services, config);

            //registrace MainWindow
            services.AddSingleton<MainWindow>();

            //sestavení provideru 
            _provider = services.BuildServiceProvider();
            
            //Zobrazení hlavního okna
            var mainWindow = _provider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
        
    }
}
