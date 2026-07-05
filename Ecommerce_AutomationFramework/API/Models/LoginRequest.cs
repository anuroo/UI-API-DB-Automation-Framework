using System.Text.Json.Serialization;

public class LoginRequest
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;
    
    [JsonPropertyName("loginPassword")]
    public string LoginPassword { get; set; } = string.Empty;

    [JsonPropertyName("loginUser")]
    public string LoginUser { get; set; } = string.Empty;
}
