using M3HW7.Enums;
using M3HW7.Models;
using M3HW7.Services.Abstractions;

namespace M3HW7.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly IFileService _fileService;

        private readonly IConfigurationService _configurationService;

        private readonly Logger _logger;

        private Config? _config;

        public LoggerService(IFileService fileService, IConfigurationService configurationService)
        {
            _fileService = fileService;
            _configurationService = configurationService;
            _logger = new Logger();
        }

        public event Predicate<int>? BackupMessageHandler;

        public async Task FirstMethodAsync(string log)
        {
            await AddLog(log);
        }

        public async Task SecondMethodAsync(string log)
        {
            await AddLog(log);
        }

        public async Task DoBackup()
        {
            await _fileService.WriteLogsToFile(_logger.Logs.ToString(), _config!.DirectoryConfig!.DirectoryName!, $"{DateTime.UtcNow.ToString(_config!.FileConfig!.FileName) + _config!.FileExtensionConfig!.TxtExtension}");
        }

        public string FormLog(string message, LogType logType)
        {
            _config = _configurationService.DesiarializeConfig("config.json");

            return $"{DateTime.UtcNow.ToString(_config!.FileConfig!.FileName)}: {logType}: {message}";
        }

        private async Task AddLog(string log)
        {
            _logger.Logs.AppendLine(log);
            _logger.QuantityOfStrings++;

            if (BackupMessageHandler!(_logger.QuantityOfStrings))
            {
                await DoBackup();
            }
        }
    }
}
