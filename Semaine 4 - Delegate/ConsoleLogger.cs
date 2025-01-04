using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaine_4___Delegate
{
    internal class ConsoleLogger : Logger
    {
        public static void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
