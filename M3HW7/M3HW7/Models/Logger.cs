using System.Text;

namespace M3HW7.Models
{
    public class Logger
    {
        public Logger()
        {
            Logs = new StringBuilder();
        }

        public int QuantityOfStrings { get; set; }

        public StringBuilder Logs { get; set; }
    }
}
