public interface ITestLogger
{
    void Info(string message);
    void Error(string message, Exception? ex = null);
}
