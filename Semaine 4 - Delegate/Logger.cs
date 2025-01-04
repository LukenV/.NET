using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaine_4___Delegate
{
    internal class Logger
    {

        public delegate void LogHandler(string message);
        public LogHandler Log;

        public void LogMessage(string message)
        {
            Log.Invoke(message);
        }

    }
}
