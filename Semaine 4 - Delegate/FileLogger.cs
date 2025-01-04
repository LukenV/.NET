using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semaine_4___Delegate
{
    internal class FileLogger
    {
        public static void LogMessage(string message)
        {
            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string message to a new file named "FileLogger.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "FileLogger.txt")))
            {
               outputFile.WriteLine(message);
            }
            Console.WriteLine("Added one txt file in Documents directory");
        }
    }
}
