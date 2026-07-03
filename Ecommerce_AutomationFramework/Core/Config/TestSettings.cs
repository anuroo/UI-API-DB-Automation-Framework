public sealed class TestSettings
{
    public string BaseUrl { get; set; }=string.Empty;
    public string ApiBaseUrl { get; set; }=string.Empty;
    public string Browser { get; set; }="chrome";
    public bool Headless { get; set; }
    public string DbConnectionString { get; set; }=string.Empty;
}