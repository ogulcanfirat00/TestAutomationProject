using Microsoft.Extensions.Configuration;

namespace APITestAutomation.Utilities
{
    public static class ConfigReader
    {
        private static IConfigurationRoot config;

        static ConfigReader()
        {
            var basePath = AppContext.BaseDirectory;
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)                                          
                .AddJsonFile(Path.Combine("Configs", "appSetting.json"),
                optional: false, reloadOnChange: true);                  
            config = builder.Build();   
        }

        public static string GetBaseUrl() => config["BaseUrl"];        
    }

}
