using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ConsoleLogger
{
    public class ConsoleLogger : IConsoleLogger
    {
        public void ClearLog()
        {
            Console.Clear();
        }

        public void LogText(string text)
        {
            Console.WriteLine(text);
        }
    }
}
