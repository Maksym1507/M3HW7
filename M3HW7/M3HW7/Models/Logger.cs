using System.Text;
using System.Threading;
using M3HW7.Services.Abstractions;

namespace M3HW7.Models
{
    public class Logger : ILogger
    {
        private IFileService _fileService;

        private int _quantityOfStrings;

        private StringBuilder _logs;

        public Logger(IFileService fileService)
        {
            _fileService = fileService;
            _logs = new StringBuilder();
        }

        public event Predicate<int> BackupMessageHandler;

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
            await _fileService.WriteToFile(_logs.ToString());
        }

        private async Task AddLog(string log)
        {
            _logs.AppendLine(log);
            _quantityOfStrings++;

            if (BackupMessageHandler(_quantityOfStrings))
            {
                await DoBackup();
            }
        }
    }
}
