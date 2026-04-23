using System.Text.Json;
using RestSharp;
[TestFixture]
public class AuthTest
{
    private AuthService _authService=null!;

    [SetUp]
    public void Setup()
    {
        _authService=new AuthService();
    }

    [Test]
    [Category("Booking API")]
    public async Task CreateAuthToken()
    {
        var authRequest=TestDataLoader.LoadJson<AuthRequest>("API/CreateAuth.json");
        ResponseLogger.PrintRequest<AuthRequest>(authRequest);
        var authResponse=await _authService.CreateAuthAsync(authRequest);
        ResponseLogger.PrintResponse(authResponse);
        ResponseValidators.ValidateStatusCode(authResponse,200);
        var tokenResponseValidation=ResponseParser.Deserialize<AuthResponse>(authResponse);
        Assert.That(tokenResponseValidation.Token,Is.Not.Null.And.Not.Empty);
    } 
}