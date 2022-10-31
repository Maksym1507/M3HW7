using M3HW7.Enums;
using M3HW7.Exceptions;
using M3HW7.Services.Abstractions;

namespace M3HW7.Models
{
    public class Actions : IActions
    {
        public string CallInfo()
        {
            return $"{DateTime.UtcNow}: {LogType.Info}: Start method: {nameof(CallInfo)}";
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
