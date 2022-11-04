using M3HW7.Models;
using M3HW7.Services;
using M3HW7.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace M3HW7
{
    internal class Program
    {
        private static async Task Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfigurationService, ConfigurationService>()
                .AddSingleton<IFileService, FileService>()
                .AddTransient<IActionService, ActionService>()
                .AddSingleton<Logger>()
                .AddTransient<ILoggerService, LoggerService>()
                .AddTransient<Starter>()
                .BuildServiceProvider();

            var starter = serviceProvider.GetRequiredService<Starter>();
            await starter.Run();
        }
    }
}