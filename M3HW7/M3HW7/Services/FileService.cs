using M3HW7.Services.Abstractions;

namespace M3HW7.Services
{
    internal class FileService : IFileService
    {
        private const string DirectoryNameForBackup = "Backup";
        public async Task WriteToFile(string data)
        {
            if (!Directory.Exists(DirectoryNameForBackup))
            {
                Directory.CreateDirectory(DirectoryNameForBackup);
            }

            var streamWriter = new StreamWriter($@"Backup\{DateTime.UtcNow:HH.mm.ss.fffff dd.MM.yyyy}.txt");
            await streamWriter.WriteAsync(data);
            await streamWriter.FlushAsync();
        }
    }
}
