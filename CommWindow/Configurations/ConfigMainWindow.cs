using Microsoft.Extensions.DependencyInjection;

namespace CommWindow.Configurations
{
    public class ConfigMainWindow : IConfigMainWindow
    {
        private ServiceProvider? _provider;
        private readonly AppConfigurations _appConfig;
        private readonly ServiceCollection _serviceColl;        

        public ConfigMainWindow(ServiceProvider provider, AppConfigurations appConfig, ServiceCollection serviceColl)
        {
            _provider = provider;
            _serviceColl = serviceColl;
            _appConfig = appConfig;
        }

        public void ConfigWindow()
        {
            _serviceColl.AddSingleton(_appConfig.ConfigurationBuilderSetup());
            _serviceColl.AddSingleton<MainWindow>();
            _provider = _serviceColl.BuildServiceProvider();
            var mainWindow = _provider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }


    }
}
