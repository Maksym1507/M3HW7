using M3HW7.Enums;
using M3HW7.Exceptions;
using M3HW7.Services.Abstractions;

namespace M3HW7
{
    public class Starter
    {
        private readonly IConfigurationService _configurationService;

        private readonly ILogger _logger;

        private readonly IActions _actions;

        private readonly Config? _config;

        private string _log;

        public Starter(IConfigurationService configurationService, ILogger logger, IActions actions)
        {
            _logger = logger;
            _configurationService = configurationService;
            _actions = actions;
            _config = _configurationService.DesiarializeConfig("config.json");
        }

        public async Task Run()
        {
            _logger.BackupMessageHandler += x =>
            {
                bool isValid = false;

                if (x % _config!.Configuration.ConfigurationNumber == 0)
                {
                    isValid = true;
                }

                return isValid;
            };

            for (int i = 0; i < 50; i++)
            {
                try
                {
                    switch (new Random().Next(1, 4))
                    {
                        case 1:
                            _log = _actions.CallInfo();
                            break;
                        case 2:
                            _actions.CallWarning();
                            break;
                        case 3:
                            _actions.CallError();
                            break;
                    }
                }
                catch (BusinessException ex)
                {
                    _log = $"{DateTime.UtcNow}: {LogType.Warning}: Action got this custom Exception: {ex.Message}";
                }
                catch (Exception ex)
                {
                    _log = $"{DateTime.UtcNow}: {LogType.Error}: Action failed by reason: {ex.Message}";
                }

                await _logger.FirstMethodAsync(_log);
                await _logger.SecondMethodAsync(_log);
            }
        }
    }
}
