using RestSharp;

public class AccountService
{
    private const string RegisterEndpoint = "/accountservice/accountrest/api/v1/register";
    private const string LoginEndPoint= "/accountservice/accountrest/api/v1/login";
    private readonly APIclient _client;

    public AccountService()
    {
        _client = new APIclient(ConfigManager.BaseUrl);
    }

    public Task<RestResponse> RegisterUserAsync(RegisterRequest request)
    {
        var restRequest = new RequestBuilder(RegisterEndpoint, Method.Post)
            .AddHeaders(new Dictionary<string, string>
            {
                ["Accept"]="application/json"
            }
            )
            .AddBody(request)
            .Build();

        return _client.ExecuteAsync(restRequest);
    }
    public  Task<RestResponse> LoginUser(LoginRequest request)
    {
        var loginRequest=new RequestBuilder(LoginEndPoint,Method.Post)
            .AddHeaders(new Dictionary<string, string>
            {
                ["Accept"]="application/json"   
            })
            .AddBody(request)
            .Build();
        return _client.ExecuteAsync(loginRequest);
    }
}
