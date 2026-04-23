using System.Text.Json.Serialization;

public class UpdateBookingRequest
{
    [JsonPropertyName("firstname")]
    public string FirstName { get; set; }=string.Empty;
    
    [JsonPropertyName("lastname")]
    public string LastName { get; set; }=string.Empty;
}