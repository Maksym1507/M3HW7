namespace M3HW7.Services.Abstractions
{
    public interface IConfigurationService
    {
        Config DesiarializeConfig(string file);
    }
}
