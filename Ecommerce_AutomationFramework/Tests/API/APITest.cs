using System.Threading.Tasks;

[TestFixture]
public class APITest
{
    private APIclient _client = null!;

    [SetUp]
    public void Setup()
    {
        _client = new APIclient(SettingsProvider.ActiveProfile.ApiBaseUrl);
    }

    [Test]
    [Category("API")]
    [Category("Integration")]
    [Ignore("Legacy scaffold. Replace with nopCommerce API endpoints once the plugin routes are confirmed.")]
    public async Task ValidateGetUserEndpoint()
    {
        var response = await _client.GetRestAsync("/catalog/api/v1/attributes/colors_pallet");
        ResponseValidators.ValidateStatusCode(response, 200);
    }
}
