using System.Text.Json;
using RestSharp;

public static class ResponseLogger
{
    public static void PrintRequest<T>(T Request)
    {
        Console.WriteLine("Request:");
        Console.WriteLine(JsonSerializer.Serialize(Request,new JsonSerializerOptions
        {
            WriteIndented=true
        }));
    }
    public static string FormatJsonIfPossible(string content)
    {
        if(string.IsNullOrWhiteSpace(content))
        {
            return "<empty>";
        }
        try{
        using var doc=JsonDocument.Parse(content);
        return JsonSerializer.Serialize(doc,new JsonSerializerOptions
        {
            WriteIndented=true
        });
        }
        catch
        {
            return content;
        }
    }
    public static void PrintResponse(RestResponse response)
    {
        Console.WriteLine("Response:-");
        Console.WriteLine("Status Code:"+(int)response.StatusCode);
        Console.WriteLine(FormatJsonIfPossible(response.Content));
    }
}