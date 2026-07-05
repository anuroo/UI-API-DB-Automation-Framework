using RestSharp;

public class AuthService
{
    private const string createTokenEndpoint= "/auth";
    private APIclient _client;

    public AuthService()
    {
        _client = new APIclient(SettingsProvider.ActiveProfile.ApiBaseUrl);
    }

    public Task<RestResponse> CreateAuthAsync(AuthRequest authRequest)
    {
        var request=new RequestBuilder(createTokenEndpoint,Method.Post)
        .AddHeaders(new Dictionary<string, string>
        {
           ["Accept"]="application/json" 
        })
        .AddBody(authRequest).Build();
        return _client.ExecuteAsync(request);
    }
    
}
