using Serilog;

namespace Evoke_Web.Architecture.Application_Layer.Extensions
{
    internal static class ApplicationExtension
    {
        public static void Build(this ConfigurationManager manager, string configuration) => manager
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(configuration, false, true)
            .AddUserSecrets<Program>(false, true)
            .AddEnvironmentVariables()
            .Build();

        public static void RegisterLogger(this IHostBuilder host, string path)
        {
            host.UseSerilog((context, configuration) => configuration
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File($@"{path}\log-.txt", rollingInterval: RollingInterval.Day));

            BuildStaticSerilogInstance(path);
        }

        public static void RegisterDependencies(this IServiceCollection services)
        {
            /* Configuration: */
            services.AddLogging(logger => logger.AddSerilog());
            services.AddControllers(options => options.EnableEndpointRouting = false);

            /* Application Layer: */
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "Architecture/Application Layer/Client/dist"; });
        }

        #region Private:

        private static void BuildStaticSerilogInstance(string path) => Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File($@"{path}\log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        #endregion
    }
}
