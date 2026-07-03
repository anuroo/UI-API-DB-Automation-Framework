public static class ReportWriter
{
    public static string WriteSummary(string message)
    {
        var reportDirectory = Path.Combine(AppContext.BaseDirectory, "Reports");
        Directory.CreateDirectory(reportDirectory);

        var reportPath = Path.Combine(reportDirectory, $"TestReport-{DateTime.UtcNow:yyyyMMdd-HHmmss}.txt");
        File.WriteAllText(reportPath, message);
        Console.WriteLine(message);
        return reportPath;
    }
}
