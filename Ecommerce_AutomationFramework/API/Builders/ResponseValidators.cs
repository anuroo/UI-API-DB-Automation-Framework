using NUnit.Framework;
using RestSharp;

public static class ResponseValidators
{
    public static void ValidateStatusCode(RestResponse restResponse, int expectedStatusCode)
    {
        Assert.That((int)restResponse.StatusCode, Is.EqualTo(expectedStatusCode));
    }

    public static void ValidateResponseContains(RestResponse restResponse, string expectedResponseContent)
    {
        Assert.That(restResponse.Content, Is.Not.Null.And.Contains(expectedResponseContent));
    }

    public static void ValidateContentNotEmpty(RestResponse restResponse)
    {
        Assert.That(restResponse.Content, Is.Not.Null.And.Not.Empty);
    }
}
