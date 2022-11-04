using M3HW7.Enums;

namespace M3HW7.Services.Abstractions
{
    public interface ILoggerService
    {
        event Predicate<int> BackupMessageHandler;

        public string FormLog(string message, LogType logType);

        Task FirstMethodAsync(string log);

        Task SecondMethodAsync(string log);

        Task DoBackup();
    }
}
