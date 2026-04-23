using System.Text.Json;
using RestSharp;

public static class ResponseParser
{
    // private static readonly JsonSerializerOptions JsonOptions = new()
    // {
    //     PropertyNameCaseInsensitive = true
    // };//This to ensure in that incase there are casing difference in response the framework can handle those

    // public static JsonDocument Parse(RestResponse response)
    // {
    //     if (string.IsNullOrWhiteSpace(response.Content))
    //     {
    //         throw new InvalidOperationException("Response content is empty and cannot be parsed.");
    //     }

    //     return JsonDocument.Parse(response.Content);
    // }

    // public static T Deserialize<T>(RestResponse response)
    // {
    //     if (string.IsNullOrWhiteSpace(response.Content))
    //     {
    //         throw new InvalidOperationException("Response content is empty and cannot be deserialized.");
    //     }

    //     var deserialized = JsonSerializer.Deserialize<T>(response.Content, JsonOptions);
    //     return deserialized ?? throw new InvalidOperationException($"Unable to deserialize response into {typeof(T).Name}.");
    // }
    public static readonly JsonSerializerOptions jsonOptions=new()
    {
        PropertyNameCaseInsensitive=true
    };
    public static JsonDocument Parse(RestResponse response)
    {
        if(string.IsNullOrWhiteSpace(response.Content))
        {
            throw new InvalidOperationException("Response content is empty and cannot be parsed");
        }
        return JsonDocument.Parse(response.Content);
    }
    public static T Deserialize<T>(RestResponse response)
    {
        if(string.IsNullOrWhiteSpace(response.Content))
        {
            throw new InvalidOperationException("Response content is empty and cannot be parsed");
        }
        var desrialized=JsonSerializer.Deserialize<T>(response.Content,jsonOptions);
        return desrialized ?? throw new InvalidOperationException("Unable to deserialize the response output");
    }
}
