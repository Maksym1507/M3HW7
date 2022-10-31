using M3HW7.Services.Abstractions;
using Newtonsoft.Json;

namespace M3HW7.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public Config DesiarializeConfig(string file)
        {
            var config = File.ReadAllText(file);
            return JsonConvert.DeserializeObject<Config>(config);
        }
    }
}
