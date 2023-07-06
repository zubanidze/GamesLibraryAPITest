namespace GamesLibrary.Extensions
{
    public static class ConfigurationConstants
    {
        public const string DefaultConfigsFolder = "DefaultConfigs";
        public const string EnvironmentConfigsFolder = "EnvironmentConfigs";
    }
    public static class ConfigExtesions
    {
        public static WebApplicationBuilder AddConfiguration(this WebApplicationBuilder builder)
        {
            builder.Configuration.AddBaseConfigs();
            builder.Configuration.AddEnvironmentConfigs(builder.Environment);

            return builder;
        }

        public static IConfigurationBuilder AddBaseConfigs(this IConfigurationBuilder config)
        {
            const string defaultConfigsFolder = ConfigurationConstants.DefaultConfigsFolder;
            config.AddJsonFile(Path.Combine(defaultConfigsFolder, "logsettings.json"));
            config.AddJsonFile(Path.Combine(defaultConfigsFolder, $"appsettings.json"));

            return config;
        }

        public static IConfigurationBuilder AddEnvironmentConfigs(this IConfigurationBuilder config, IHostEnvironment environment)
        {
            const string environmentConfigsFolder = ConfigurationConstants.EnvironmentConfigsFolder;
            string environmentName = environment.EnvironmentName;

            config.AddJsonFile(Path.Combine(environmentName, $"logsettings.{environmentName}.json"), true);
            config.AddJsonFile(Path.Combine(environmentConfigsFolder, $"appsettings.{environmentName}.json"), true);

            return config;
        }
    }
}
