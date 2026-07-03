public sealed class FileTestLogger : ITestLogger
{
    private static readonly string LogDirectory = Path.Combine(AppContext.BaseDirectory, "Reports");
    private static readonly string LogFilePath = Path.Combine(LogDirectory, "execution.log");

    public void Info(string message)
    {
        Write("INFO", message);
    }

    public void Error(string message, Exception? error = null)
    {
        Write("ERROR", message);
        if (error != null)
            Write("ERROR", error.ToString());
    }

    private static void Write(string level, string message)
    {
        Directory.CreateDirectory(LogDirectory);
        var line = $"{DateTime.UtcNow:O} [{level}] {message}";
        Console.WriteLine(line);
        File.AppendAllText(LogFilePath, line + Environment.NewLine);
    }
}
