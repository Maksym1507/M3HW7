namespace M3HW7.Services.Abstractions
{
    public interface IActionService
    {
        public string CallInfo();

        public void CallWarning();

        public void CallError();
    }
}
