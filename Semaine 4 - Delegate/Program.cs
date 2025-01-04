using Semaine_4___Delegate;

internal class Program
{
    private static void Main(string[] args)
    {
        Logger logger = new Logger();

        logger.Log += FileLogger.LogMessage;
        logger.Log += ConsoleLogger.LogMessage;

        logger.LogMessage("Testing Console and File loggers");
    }
}