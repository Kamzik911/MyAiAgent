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
        void ConfigWindow();
    }

    interface IServiceSetup
    {
        IServiceCollection ChatServiceSetup();
    }
}
