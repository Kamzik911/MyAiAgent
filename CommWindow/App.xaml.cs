using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAiAgent.Interfaces;
using MyAiAgent.Services;
using CommWindow.Configurations;

namespace CommWindow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider? _provider;
        private readonly IServiceSetup _serviceSetup;
        private readonly ConfigMainWindow _configMainWindow;
        private readonly AppConfigurations _appConfigurations;

        public App(ServiceSetup serviceSetup, ConfigMainWindow configMainWindow, AppConfigurations appConfigurations)
        {
            _serviceSetup = serviceSetup;
            _configMainWindow = configMainWindow;
            _appConfigurations = appConfigurations;
        }
        
        public void StartApp()
        {            
            _appConfigurations.ConfigurationBuilderSetup();
            _serviceSetup.ChatServiceSetup();
            _configMainWindow.ConfigWindow();
        }

        public void Dispose()
        {
            if (_provider != null)
            {
                _provider.Dispose();
            }
        }

        
    }
}
