using System;
using Microsoft.Extensions.DependencyInjection;

namespace CommWindow.Configurations
{
    public class ConfigMainWindow : IConfigMainWindow
    {
        private ServiceProvider? _serviceProvider;
        private readonly AppConfigurations _appConfig;
        private readonly ServiceCollection _serviceColl;        

        public ConfigMainWindow(ServiceProvider serviceProvider, AppConfigurations appConfig, ServiceCollection serviceColl)
        {
            _serviceProvider = serviceProvider;
            _serviceColl = serviceColl;
            _appConfig = appConfig;
        }

        public void ConfigWindow()
        {
            _serviceColl.AddSingleton(_appConfig.ConfigurationBuilderSetup());
            _serviceColl.AddSingleton<MainWindow>();
            _serviceProvider = _serviceColl.BuildServiceProvider();
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
        public void Dispose()
        {
            if (_serviceProvider != null)
            {
                _serviceProvider.Dispose();
            }
        }

    }
}
