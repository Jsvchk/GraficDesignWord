
public interface ILogger
{
    void LogMessage(string message);
}

// Клас для логування повідомлень
public class MyLogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Адаптація: {message}");
    }
}

// Адаптер, який реалізує інтерфейс ILogger та використовує клас MyLogger
public class LoggerAdapter : ILogger
{
    private MyLogger myLogger;

    public LoggerAdapter(MyLogger myLogger)
    {
        this.myLogger = myLogger;
    }

    public void LogMessage(string message)
    {
        myLogger.Log(message);
    }
}

// Клас, який використовує інтерфейс ILogger
public class Application
{
    private ILogger logger;

    public Application(ILogger logger)
    {
        this.logger = logger;
    }

    public void Run()
    {
        logger.LogMessage("Адаптація завершена.");
    }
}

// Використання
class Program
{
    static void Main(string[] args)
    {
        // Створення екземпляра
        MyLogger myLogger = new MyLogger();

        // Створення адаптера
        ILogger loggerAdapter = new LoggerAdapter(myLogger);

        // Створення додатку
        Application app = new Application(loggerAdapter);

        // Запуск
        app.Run();
    }
}

