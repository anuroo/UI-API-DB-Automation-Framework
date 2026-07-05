using System.Text.Json;
using System.Threading.Tasks;

[TestFixture]
[Ignore("Legacy scaffold. Replace with nopCommerce account/API tests.")]
public class AccountServiceTest
{
    private AccountService _accountService = null!;

    [SetUp]
    public void Setup()
    {
        _accountService = new AccountService();
    }

    [Test]
    [Category("API")]
    [Category("Integration")]
    [Explicit("Requires live registration endpoint and valid Advantage Demo test data.")]
    public async Task RegisterUser_ShouldReturnSuccessResponse()
    {
        var request = TestDataLoader
            .LoadJson<RegisterRequest>("API/register-user.json");
            // .WithUniqueIdentity(DateTime.UtcNow.ToString("yyyyMMddHHmmss"));

        var response = await _accountService.RegisterUserAsync(request);

        ResponseValidators.ValidateStatusCode(response, 200);
        ResponseValidators.ValidateContentNotEmpty(response);

        using var responseJson = ResponseParser.Parse(response);
        Assert.That(responseJson.RootElement.ValueKind, Is.Not.EqualTo(JsonValueKind.Undefined));
    }
    [Test]
    [Category("API")]
    [Category("Integration")]
    public async Task LoginUser_ShouldReturnSuccessResponse()
    {
        var request=TestDataLoader
        .LoadJson<LoginRequest>("API/Login-user.json");
        
        var response=await _accountService.LoginUser(request);
        ResponseValidators.ValidateStatusCode(response,200);

    }

}
