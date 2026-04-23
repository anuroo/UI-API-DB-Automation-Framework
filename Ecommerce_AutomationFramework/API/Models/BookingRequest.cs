using System.Text.Json.Serialization;

public class BookingRequest
{
    [JsonPropertyName("firstname")]
    public string FirstName { get; set; }=string.Empty;
    
    [JsonPropertyName("lastname")]
    public string LastName { get; set; }=string.Empty;
    
    [JsonPropertyName("totalprice")]
    public int TotalPrice { get; set; }

    [JsonPropertyName("depositpaid")]
    public bool DepositPaid { get; set; }

    [JsonPropertyName("bookingdates")]
    public BookingDates BookingUpdates { get; set; }=new ();
    
    [JsonPropertyName("additionalneeds")]
    public string AdditionalNeeds { get; set; }=string.Empty;
}

public class BookingDates
{
    [JsonPropertyName("checkin")]
    public string Checkin { get; set; }=string.Empty;

    [JsonPropertyName("checkout")]
    public string Checkout { get; set; }=string.Empty;
}