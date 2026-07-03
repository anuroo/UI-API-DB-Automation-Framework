using System.Security.Cryptography.X509Certificates;
using RestSharp;

public class BookingService
{
    private const string getAllBookingIdEndpoint="/booking";
    private static string updateBookingEndpoint(int bookingId) => $"/booking/{bookingId}";
    private APIclient _client;

    public BookingService()
    {
        _client=new APIclient(ConfigManager.BaseUrl2);
    }
    public Task<RestResponse> GetAllBookingIdsAsync()
    {
        var bookrequest=new RequestBuilder(getAllBookingIdEndpoint,Method.Get)
        .AddHeaders(new Dictionary<string, string>()
        {
            ["Accept"]="application/json"
        }
        ).Build();
        return _client.ExecuteAsync(bookrequest);
    }
     public Task<RestResponse> GetBookingIdByNameAsync()
    {
        var bookrequest=new RequestBuilder(getAllBookingIdEndpoint,Method.Get)
        .AddHeaders(new Dictionary<string, string>()
        {
            ["Accept"]="application/json"
        }
        ).AddQueryParameters(new Dictionary<string, string>
        {
            ["firstname"]="sally",
            ["lastname"]="brown"
        }).Build();
        return _client.ExecuteAsync(bookrequest);
    }
    public Task<RestResponse> CreateBookingAsync(BookingRequest restRequest)
    {
        var createBookRequest=new RequestBuilder(getAllBookingIdEndpoint,Method.Post)
        .AddHeaders(new Dictionary<string, string>
        {
            ["Accept"]="application/json"
        }).AddBody(restRequest).Build();

        return _client.ExecuteAsync(createBookRequest);
    }
    public Task<RestResponse> UpdateBookingAsync(int bookingid,BookingRequest updateRequest,string token)
    {
        var updateBookingRequest=new RequestBuilder(updateBookingEndpoint(bookingid),Method.Put)
        .AddHeaders(new Dictionary<string, string>
        {
            ["Accept"]="application/json",
            ["Cookie"]=$"token={token}"
        }).AddBody(updateRequest).Build();

        return _client.ExecuteAsync(updateBookingRequest);
    }
    public Task<RestResponse>GetBookingByIdAsync(int bookingID)
    {
        var request=new RequestBuilder($"/booking/{bookingID}",Method.Get)
        .AddHeaders(new Dictionary<string, string>
        {
            ["Accept"]="application/json"
        }).Build();
        return _client.ExecuteAsync(request);
    }
    public Task<RestResponse> DeleteBookingIdAsync(int bookingID,string token)
    {
        var request=new RequestBuilder($"/booking/{bookingID}",Method.Delete)
        .AddHeaders(new Dictionary<string, string>
        {
           ["Cookie"]=$"token={token}" 
        }).Build();
        return _client.ExecuteAsync(request);
    }
}