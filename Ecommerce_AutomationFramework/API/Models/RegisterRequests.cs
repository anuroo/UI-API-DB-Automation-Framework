using System.Text.Json.Serialization;

public class RegisterRequest
{
    [JsonPropertyName("accountType")]
    public string AccountType { get; set; } = string.Empty;

    [JsonPropertyName("address")]
    public string Address { get; set; } = string.Empty;

    [JsonPropertyName("allowOffersPromotion")]
    public bool AllowOffersPromotion { get; set; }

    [JsonPropertyName("aobUser")]
    public bool AobUser { get; set; }

    [JsonPropertyName("cityName")]
    public string CityName { get; set; } = string.Empty;

    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("lastName")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("loginName")]
    public string LoginName { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; } = string.Empty;

    [JsonPropertyName("stateProvince")]
    public string StateProvince { get; set; } = string.Empty;

    [JsonPropertyName("zipCode")]
    public string ZipCode { get; set; } = string.Empty;

    public RegisterRequest WithUniqueIdentity(string suffix)
    {
        LoginName = $"{LoginName}{suffix}";

        var emailParts = Email.Split('@');
        if (emailParts.Length == 2)
        {
            Email = $"{emailParts[0]}{suffix}@{emailParts[1]}";
        }

        return this;
    }
}
