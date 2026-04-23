using RestSharp;

public class RequestBuilder
{
    private readonly RestRequest _request;

    public RequestBuilder(string endpoint, Method method)
    {
        _request = new RestRequest(endpoint, method);
    }

    public RequestBuilder AddHeaders(Dictionary<string, string> headers)
    {
        foreach (var header in headers)
        {
            _request.AddHeader(header.Key, header.Value);
        }

        return this;
    }

    public RequestBuilder AddBody(object body)
    {
        _request.AddJsonBody(body);
        return this;
    }

    public RestRequest Build()
    {
        return _request;
    }
    public RequestBuilder AddQueryParameters(Dictionary<string,string> QueryParams)
    {
        foreach(var parameter in QueryParams)
        {
            _request.AddQueryParameter(parameter.Key,parameter.Value);
        } 
        return this;
    }
}
