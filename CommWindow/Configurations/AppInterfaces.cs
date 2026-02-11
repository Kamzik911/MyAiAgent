using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommWindow.Configurations
{
    interface IAppConfigs
    {
        IConfiguration ConfigurationBuilderSetup();
    }

    interface IConfigMainWindow
    {
        void ConfigWindow();        
    }

    interface IServiceSetup
    {
        void ChatServiceSetup(IServiceCollection services, IConfiguration config);
    }
}
