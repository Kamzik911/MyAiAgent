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
        void Dispose();
    }

    interface IServiceSetup
    {
        void ChatServiceSetup(IServiceCollection services, IConfiguration config);
    }
}
