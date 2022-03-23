using Serilog;
using Serilog.Sinks.Elasticsearch;
using System.Reflection;

namespace SerilogSample.Configurations
{
    public static class LoggingConfig
    {
      
        public static void ConfigureLogging()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).AddJsonFile($"appsettings.{env}.json", optional: true).Build();


            Log.Logger = new LoggerConfiguration()
                .WriteTo.Elasticsearch(ConfigureElasticSinks(configuration, env))
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        private static ElasticsearchSinkOptions ConfigureElasticSinks(IConfigurationRoot configuration, string environment)
        {
            return new ElasticsearchSinkOptions
            {
                
                AutoRegisterTemplate = true,
                IndexFormat = $"{Assembly.GetExecutingAssembly()?.GetName()?.Name?.ToLower()}-{environment.ToLower()}",

            };

        }
    }
}
