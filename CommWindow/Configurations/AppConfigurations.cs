using Microsoft.Extensions.Configuration;

namespace CommWindow.Configurations
{
    public class AppConfigurations : IAppConfigs
    {        
        public IConfiguration ConfigurationBuilderSetup()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets<App>()
                .Build();            
        }                
    }
}
