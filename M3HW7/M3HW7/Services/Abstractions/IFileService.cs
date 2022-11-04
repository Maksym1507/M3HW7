namespace M3HW7.Services.Abstractions
{
    public interface IFileService
    {
        public Task WriteLogsToFile(string data, string directoryName, string fileName);
    }
}
