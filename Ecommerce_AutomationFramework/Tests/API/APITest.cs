using System.Threading.Tasks;

[TestFixture]
public class APITest
{
    private APIclient _client = null!;

    [SetUp]
    public void Setup()
    {
        _client = new APIclient(ConfigManager.BaseUrl);
    }

    [Test]
    [Category("API")]
    [Category("Integration")]
    [Explicit("Endpoint contract is not yet confirmed for this environment.")]
    public async Task ValidateGetUserEndpoint()
    {
        var response = await _client.GetRestAsync("/catalog/api/v1/attributes/colors_pallet");
        ResponseValidators.ValidateStatusCode(response, 200);
    }
}
