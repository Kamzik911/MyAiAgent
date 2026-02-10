using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommWindow.Configurations
{
    public class ConfigMainWindow : IConfigMainWindow
    {
        private IServiceCollection _serviceColl;
        private IConfiguration _config;

        public ConfigMainWindow(IServiceCollection serviceColl, IConfiguration config)
        {
            _serviceColl = serviceColl;
            _config = config;
        }

        public ServiceProvider ConfigWindow()
        {            
            _serviceColl.AddSingleton<MainWindow>();
            var provider = _serviceColl.BuildServiceProvider();
            var mainWindow = provider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            return provider;
        }
    }
}
