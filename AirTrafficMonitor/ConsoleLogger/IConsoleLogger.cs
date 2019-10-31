using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.ConsoleLogger
{
    public interface IConsoleLogger
    {
        void LogText(string text);
        void ClearLog();

    }
}
