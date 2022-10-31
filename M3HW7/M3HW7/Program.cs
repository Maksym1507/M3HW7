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
                .AddTransient<IConfigurationService, ConfigurationService>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<IActions, Actions>()
                .AddSingleton<ILogger, Logger>()
                .AddTransient<Starter>()
                .BuildServiceProvider();

            var starter = serviceProvider.GetRequiredService<Starter>();
            await starter.Run();
        }
    }
}