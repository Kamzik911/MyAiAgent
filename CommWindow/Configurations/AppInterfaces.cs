using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommWindow.Configurations
{
    interface IAppConfigurations
    {
        IConfiguration ConfigurationBuilderSetup();
    }

    interface IConfigMainWindow
    {
        ServiceProvider ConfigWindow();        
    }

    interface IServiceSetup
    {
        void ChatServiceSetup(IServiceCollection services, IConfiguration config);
    }
}
