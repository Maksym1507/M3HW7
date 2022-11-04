using M3HW7.Enums;
using M3HW7.Exceptions;
using M3HW7.Services.Abstractions;

namespace M3HW7.Services
{
    public class ActionService : IActionService
    {
        private readonly ILoggerService _loggerService;

        public ActionService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public string CallInfo()
        {
            return _loggerService.FormLog($"Start method: {nameof(CallInfo)}", LogType.Info);
        }

        public void CallWarning()
        {
            throw new BusinessException($"Skipped logic in method {nameof(CallWarning)}");
        }

        public void CallError()
        {
            throw new Exception("I broke logic");
        }
    }
}
