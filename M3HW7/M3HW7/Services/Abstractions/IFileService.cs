namespace M3HW7.Services.Abstractions
{
    public interface IFileService
    {
        public Task WriteToFile(string data);
    }
}
