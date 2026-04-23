using System.Text.Json.Serialization;

public class AuthRequest
{
    [JsonPropertyName("username")]
    public string UserName { get; set; } =string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; }=string.Empty;

}