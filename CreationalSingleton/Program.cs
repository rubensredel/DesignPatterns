namespace CreationalSingleton;

public class Logger
{
    private static Logger? _instance;
    private string logData;

    private Logger()
    {
        logData = "Begin log data";
    }

    public static Logger Instance
    {
        get
        {
            _instance ??= new Logger();
            return _instance;
        }
    }

    public void Log(string message)
    {
        logData += $"{DateTime.Now}: {message}\n";
    }

    public void PrintLog()
    {
        Console.WriteLine(logData);
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Console.Title = "Singleton");
        Logger logger = Logger.Instance;
        logger.Log("First log message");
        logger.Log("Second log message");
        logger.Log("Third log message");
        logger.PrintLog();

        logger.Log("Fourth log message");
        logger.PrintLog();

        Logger logger2 = Logger.Instance;
        logger2.Log("Fifth log message");
        logger2.PrintLog();

        Console.WriteLine("Same instance? " + (logger == logger2));
    }
}
