namespace M3HW7.Services.Abstractions
{
    public interface ILogger
    {
        event Predicate<int> BackupMessageHandler;

        Task FirstMethodAsync(string log);

        Task SecondMethodAsync(string log);

        Task DoBackup();
    }
}
