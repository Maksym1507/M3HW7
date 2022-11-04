using M3HW7.Services.Abstractions;

namespace M3HW7.Services
{
    public class FileService : IFileService
    {
        public async Task WriteLogsToFile(string data, string directoryName, string fileName)
        {
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            await File.WriteAllTextAsync($@"{directoryName}\{fileName}", data);
        }
    }
}
