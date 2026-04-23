using RestSharp;

public sealed class APIclient
{
    private readonly RestClient _restClient;

    public APIclient(string baseUrl)
    {
        _restClient = new RestClient(baseUrl);
    }

    public Task<RestResponse> GetRestAsync(string endpoint)
    {
        var request = new RestRequest(endpoint, Method.Get);
        return _restClient.ExecuteAsync(request);
    }

    public Task<RestResponse> PostAsync(string endpoint, object body)
    {
        var request = new RestRequest(endpoint, Method.Post);
        request.AddJsonBody(body);
        return _restClient.ExecuteAsync(request);
    }

    public Task<RestResponse> ExecuteAsync(RestRequest request)
    {
        return _restClient.ExecuteAsync(request);
    }
}
