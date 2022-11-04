using M3HW7.Enums;
using M3HW7.Exceptions;
using M3HW7.Services.Abstractions;

namespace M3HW7
{
    public class Starter
    {
        private readonly IConfigurationService _configurationService;

        private readonly ILoggerService _loggerService;

        private readonly IActionService _actions;

        private Config? _config;

        private string? _log;

        public Starter(IConfigurationService configurationService, ILoggerService loggerService, IActionService actions)
        {
            _loggerService = loggerService;
            _configurationService = configurationService;
            _actions = actions;
        }

        public async Task Run()
        {
            _config = _configurationService.DesiarializeConfig("config.json");

            _loggerService.BackupMessageHandler += x =>
            {
                bool isValid = false;

                if (x % _config!.NumberConfig!.ConfigurationNumber == 0)
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
                    _log = _loggerService.FormLog($"Action got this custom Exception: {ex.Message}", LogType.Warning);
                }
                catch (Exception ex)
                {
                    _log = _loggerService.FormLog($"Action failed by reason: {ex.Message}", LogType.Error);
                }

                await _loggerService.FirstMethodAsync(_log!);
                await _loggerService.SecondMethodAsync(_log!);
            }
        }
    }
}
