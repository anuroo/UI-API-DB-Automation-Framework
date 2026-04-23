using System.Text.Json;

public static class TestDataLoader
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static T LoadJson<T>(string relativePath)
    {
        var fullPath = ResolvePath(relativePath);
        var json = File.ReadAllText(fullPath);

        var data = JsonSerializer.Deserialize<T>(json, JsonOptions);
        return data ?? throw new InvalidOperationException($"Unable to deserialize test data from {fullPath}.");
    }

    private static string ResolvePath(string relativePath)
    {
        var outputPath = Path.Combine(AppContext.BaseDirectory, "Ecommerce_AutomationFramework", "TestData", relativePath);
        if (File.Exists(outputPath))
        {
            return outputPath;
        }

        var projectPath = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Ecommerce_AutomationFramework", "TestData", relativePath);
        projectPath = Path.GetFullPath(projectPath);

        if (File.Exists(projectPath))
        {
            return projectPath;
        }

        throw new FileNotFoundException($"Test data file was not found for path '{relativePath}'.");
    }
}
