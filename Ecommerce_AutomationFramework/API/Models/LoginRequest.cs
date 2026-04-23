using System.Text.Json.Serialization;

public class LoginRequest
{
    [JsonPropertyName("email")]
    public string Email { get; set; }
    
    [JsonPropertyName("loginPassword")]
    public string LoginPassword { get; set; }

    [JsonPropertyName("loginUser")]
    public string LoginUser { get; set; }
}