using System;
using Microsoft.Extensions.DependencyInjection;

namespace CommWindow.Configurations
{
    public class ConfigMainWindow : IConfigMainWindow
    {
        private ServiceProvider? _serviceProvider;                
               
        public void ConfigWindow()
        {            
            var _serviceColl = new ServiceCollection();
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
